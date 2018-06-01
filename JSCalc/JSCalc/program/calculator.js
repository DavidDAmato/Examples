// See: https://embed.plnkr.co/9hK5Lj/
function Calculator() {
}

Calculator.prototype.add = function () {
    var operands = Array.prototype.slice.call(arguments);
    var sum = 0;
    for (var i = 0; i < operands.length; i++) {
        sum += operands[i];
    }

    return sum;
}
/*

// return true if the number is either all numbers, 1234, or parsable as a int, "123455"
function isNumber(n) {
    return /^-?[\d.]+(?:e-?\d+)?$/.test(n);
} 

export class MyMath {
    // add 2 numbers and return result
    Add(a, b) {
        return Number(a) + Number(b);
    }
    // subtract 2 numbers and return result
    Subtract(a, b) {
        return Number(a) - Number(b);
    }
    // multiply 2 numbers and return result
    Multiply(a, b) {
        return Number(a) * Number(b);
    }
    // divide 2 numbers and return result
    Divide(a, b) {
        return Number(a) / Number(b);
    }
}

// do checks and math
function RunCalculator() {
    var a = document.getElementById("num1").value;
    var b = document.getElementById("num2").value;
    var opperation = document.getElementById("opperation").value;
    var newMath = new MyMath();
    var docInnerHtml = document.getElementById("answer");

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
            docInnerHtml.innerHTML = newMath.Add(a, b);
        }
        else if (opperation === "-") {
            docInnerHtml.innerHTML = newMath.Subtract(a, b);
        }
        else if (opperation === "*") {
            docInnerHtml.innerHTML = newMath.Multiply(a, b);;
        }
        else if (opperation === "\\") {
            docInnerHtml.innerHTML = newMath.Divide(a, b);
        }
        else {
            docInnerHtml.innerHTML = "Invalid opperation type, use +, -, *, or \\ ";
        }

    }
    
}

*/