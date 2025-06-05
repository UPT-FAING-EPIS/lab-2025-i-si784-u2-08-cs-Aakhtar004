using NUnit.Framework;
using TechTalk.SpecFlow;
using System;

namespace Calculator.Domain.Tests.Steps
{
    /// <summary>
    /// Clase de pruebas para la calculadora usando SpecFlow
    /// </summary>
    [Binding]
    public sealed class CalculatorTests
    {
        /// <summary>
        /// Contexto del escenario actual
        /// </summary>
        private readonly ScenarioContext _scenarioContext;
        
        /// <summary>
        /// Instancia de la calculadora bajo prueba
        /// </summary>
        public Calculator Calculadora { get; set; }
        
        /// <summary>
        /// Primer operando de la operación
        /// </summary>
        private int _operador01 { get; set; }
        
        /// <summary>
        /// Segundo operando de la operación
        /// </summary>
        private int _operador02 { get; set; }
        
        /// <summary>
        /// Resultado de la operación
        /// </summary>
        private int _resultado { get; set; }
        
        /// <summary>
        /// Excepción capturada durante la prueba
        /// </summary>
        private Exception _excepcionCapturada { get; set; }
        
        /// <summary>
        /// Constructor que inicializa el contexto y la calculadora
        /// </summary>
        /// <param name="scenarioContext">Contexto del escenario</param>
        public CalculatorTests(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Calculadora = new Calculator();
        }

        [Given("El numero (.*)")]
        public void DadoElNumero(int operando01)
        {
            _operador01 = operando01;
        }

        [Given("el numero (.*)")]
        public void yElNumero(int operando02)
        {
            _operador02 = operando02;
        }

        [When("sumo")]
        public void CuandoSumo()
        {
            _resultado = Calculadora.Add(_operador01,_operador02);
        }

        [When("resto")]
        public void CuandoResto()
        {
            _resultado = Calculadora.Subtract(_operador01,_operador02);
        }

        [When("multiplico")]
        public void CuandoMultiplico()
        {
            _resultado = Calculadora.Multiply(_operador01, _operador02);
        }

        [When("divido")]
        public void CuandoDivido()
        {
            try
            {
                _resultado = Calculadora.Divide(_operador01, _operador02);
            }
            catch (Exception ex)
            {
                _excepcionCapturada = ex;
            }
        }

        [Then("el resultado es (.*)")]
        public void EntoncesElResultadoDeberiaSer(int resultado)
        {
            Assert.That(_resultado, Is.EqualTo(resultado));
        }

        [Then("obtengo una excepcion de division por cero")]
        public void EntoncesObtengoUnaExcepcionDeDivisionPorCero()
        {
            Assert.That(_excepcionCapturada, Is.Not.Null);
            Assert.That(_excepcionCapturada, Is.TypeOf<DivideByZeroException>());
        }
    }
}