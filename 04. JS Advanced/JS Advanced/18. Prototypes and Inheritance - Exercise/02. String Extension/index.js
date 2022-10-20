(function solve() {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            return str + this;
        }
        return this.toString();
    }
    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return this + str;
        }
        return this.toString();
    }
    String.prototype.isEmpty = function () {
        return this.toString() === '';
    }
    String.prototype.truncate = function (n) {
        if (this.length <= n) {
            return this.toString();
        }
        if (n < 4) {
            return '.'.repeat(n);
        }
        let strToArr = this.split(' ');
        let result = '';
        for (let i = 0; i < strToArr.length; i++) {
            if (result.length + strToArr[i].length + 3 > n) {
                if (i === 0) {
                    result = strToArr[i];
                }
                result = result.trim();
                break;
            }
            result += ' ' + strToArr[i];
            result = result.trimStart();
        }
        if (strToArr.length < 2) {
            let newResult = '';
            for (let i = 0; i < n - 3; i++) {
                newResult += result[i];
            }
            result = newResult;
        }
        return result + '...';
    }
    String.format = function (string, ...params) {
        for (let i = 0; i < params.length; i++) {
            if (string.includes(`{${i}}`)) {
                string = string.replace(`{${i}}`.toString(), params[i]);
            }
        }
        return string;
    }
})();