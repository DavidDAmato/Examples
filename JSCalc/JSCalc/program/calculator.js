function Calculator()
{
}

Calculator.prototype.add = function (a, b)
{
    return Number(a) + Number(b);
}

Calculator.prototype.subtract = function (a, b)
{
    return Number(a) - Number(b);
}

Calculator.prototype.multiply = function (a, b)
{
    return Number(a) * Number(b);
}

Calculator.prototype.divide = function (a, b)
{
    return Number(a) / Number(b);
}

// return true if the number is either all numbers, 1234, or parsable as a int, "123455"
function isNumber(n) {
    return /^-?[\d.]+(?:e-?\d+)?$/.test(n);
} 

// do checks and math
function RunCalculator() {
    var a = document.getElementById("num1").value;
    var b = document.getElementById("num2").value;
    var opperation = document.getElementById("opperation").value;
    var docInnerHtml = document.getElementById("answer");
    var calc = new Calculator();
    // validate
    if (!(isNumber(a))) {
        docInnerHtml.innerHTML = "The first input must a valid integer, ex: 123.";
    }
    else if (!(isNumber(b))) {
        docInnerHtml.innerHTML = "The second input must a valid integer, ex: 123.";
    }
    else
    {
        // check opperation type
        if (opperation === "+") {
            docInnerHtml.innerHTML = calc.add(a, b);
        }
        else if (opperation === "-") {
            docInnerHtml.innerHTML = calc.subtract(a, b);
        }
        else if (opperation === "*") {
            docInnerHtml.innerHTML = calc.multiply(a, b);;
        }
        else if (opperation === "\\") {
            docInnerHtml.innerHTML = calc.divide(a, b);
        }
        else {
            docInnerHtml.innerHTML = "Invalid opperation type, use +, -, *, or \\ ";
        }

    }
    
}