using Microsoft.AspNetCore.Mvc;

namespace RestCalculadora.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sun/{firstNumber}/{secondNumber}")]
    public IActionResult Get(String firstNumber, String secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sun = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sun.ToString());
        }
        return BadRequest("Invalid input!");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(String firstNumber, String secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sun = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sun.ToString());
        }
        return BadRequest("Invalid input!");
    }

    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplication(String firstNumber, String secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sun = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(sun.ToString());
        }
        return BadRequest("Invalid input!");
    }

    [HttpGet("mean/{firstNumber}/{secondNumber}")]
    public IActionResult Mean(String firstNumber, String secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sun = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
            return Ok(sun.ToString());
        }
        return BadRequest("Invalid input!");
    }

    [HttpGet("square-root/{firstNumber}")]
    public IActionResult SquareRoot(String firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            var squareRoot = Math.Sqrt((double)ConvertToDecimal(firstNumber));
            return Ok(squareRoot.ToString());
        }
        return BadRequest("Invalid input!");
    }

    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult Division(String firstNumber, String secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sun = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(sun.ToString());
        }
        return BadRequest("Invalid input!");
    }
    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if(decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }
        return 0;
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo, out number);

        return isNumber;
    }
}
