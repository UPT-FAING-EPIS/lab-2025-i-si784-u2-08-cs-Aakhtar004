namespace Calculator.Domain;

/// <summary>
/// Calculadora básica que realiza operaciones aritméticas fundamentales
/// </summary>
public class Calculator
{
    /// <summary>
    /// Suma dos números enteros
    /// </summary>
    /// <param name="x">Primer operando</param>
    /// <param name="y">Segundo operando</param>
    /// <returns>La suma de x e y</returns>
    public int Add(int x, int y) => x + y;

    /// <summary>
    /// Resta dos números enteros
    /// </summary>
    /// <param name="x">Minuendo</param>
    /// <param name="y">Sustraendo</param>
    /// <returns>La diferencia de x menos y</returns>
    public int Subtract(int x, int y) => x - y;

    /// <summary>
    /// Multiplica dos números enteros
    /// </summary>
    /// <param name="x">Primer factor</param>
    /// <param name="y">Segundo factor</param>
    /// <returns>El producto de x por y</returns>
    public int Multiply(int x, int y) => x * y;

    /// <summary>
    /// Divide dos números enteros
    /// </summary>
    /// <param name="x">Dividendo</param>
    /// <param name="y">Divisor</param>
    /// <returns>El cociente de x dividido por y</returns>
    /// <exception cref="DivideByZeroException">Se lanza cuando y es cero</exception>
    public int Divide(int x, int y)
    {
        if (y == 0)
            throw new DivideByZeroException("No se puede dividir por cero");
        return x / y;
    }
}