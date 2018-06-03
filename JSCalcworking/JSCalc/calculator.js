var opperation = document.getElementById("opperation").value;
var a = document.getElementById("num1").value;
var b = document.getElementById("num2").value;

// do checks and math
function Eval() {
    // validate
    if (!(isNumber(a))) {
        document.getElementById("error").innerHTML = "The first input must a valid integer, ex: 123.";
    }
    if (!(isNumber(b))) {
        document.getElementById("error").innerHTML = "The second input must a valid integer, ex: 123.";
    }

    // check opperation type
    if (opperation === "+") {
        document.getElementById("error").innerHTML = Add(a,b);
    }
    else if (opperation === "-") {
        document.getElementById("error").innerHTML = Subtract(a, b);
    }
    else if (opperation === "*") {
        document.getElementById("error").innerHTML = Multiply(a, b);
    }
    else if (opperation === "\\") {
        document.getElementById("error").innerHTML = Divide(a, b);
    }
    else
    {
        document.getElementById("error").innerHTML = "Invalid opperation type, use +, -, *, or \\ ";
    }

}