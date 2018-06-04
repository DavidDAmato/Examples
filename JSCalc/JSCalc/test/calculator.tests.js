describe('Given the Calculator', function() {
    var calc = new Calculator();
    var sum;

    //add
    it('Then it contains an add method', function() {
        expect(calc.add).toBeDefined();
    });

    describe('When I add two numbers', function() {

        it('Then the I get the correct answer', function() {
            sum = calc.add(1, 2);
            expect(sum).toBe(3);
        });
    });

    //subtract
    it('Then it contains an subtract method', function () {
        expect(calc.subtract).toBeDefined();
    });

    describe('When I subtract two numbers', function () {

        it('Then the I get the correct answer', function () {
            sum = calc.subtract(4, 2);
            expect(sum).toBe(2);
        });
    });

    //multipy
    it('Then it contains an multiply method', function () {
        expect(calc.subtract).toBeDefined();
    });

    describe('When I multiply two numbers', function () {

        it('Then the I get the correct answer', function () {
            sum = calc.multiply(4, 2);
            expect(sum).toBe(8);
        });
    });
    
    //divide
    it('Then it contains an divide method', function () {
        expect(calc.subtract).toBeDefined();
    });

    describe('When I divide two numbers', function () {

        it('Then the I get the correct answer', function () {
            sum = calc.divide(9, 3);
            expect(sum).toBe(3);
        });
    });

});

/*

describe("Add", function () {
    it("Adds two integers", function () {
        var result = calculator.Add(5, 10);
        expect(result).toEqual(15);
    });
}).call(this);
*/