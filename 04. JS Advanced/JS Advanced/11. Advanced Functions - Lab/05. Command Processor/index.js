function solution() {
    let text = '';
    return {
        append: function (string) {
            text += string;
        },
        removeStart: function (n) {
            text = text.substring(n, text.length);
        },
        removeEnd: function (n) {
            text = text.substring(0, text.length - n);
        },
        print: function () {
            console.log(text);
        }
    };
}