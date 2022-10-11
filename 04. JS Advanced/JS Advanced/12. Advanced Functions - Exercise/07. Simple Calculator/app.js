function calculator() {
    return {
        num1: undefined,
        num2: undefined,
        result: undefined,
        init: function (selector1, selector2, resultSelector) {
            this.num1 = document.querySelector(selector1);
            this.num2 = document.querySelector(selector2);
            this.result = document.querySelector(resultSelector);
        },
        add: function () {
            this.result.value = Number(this.num1.value) + Number(this.num2.value);
        },
        subtract: function () {
            this.result.value = Number(this.num1.value) - Number(this.num2.value);
        }
    };
}



