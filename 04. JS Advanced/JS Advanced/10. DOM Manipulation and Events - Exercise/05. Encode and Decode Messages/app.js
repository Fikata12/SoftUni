function encodeAndDecodeMessages() {
    let encode = document.getElementsByTagName('button')[0];
    let decode = document.getElementsByTagName('button')[1];
    encode.addEventListener('click', function () {
        let text = document.getElementsByTagName('textarea')[0];
        let encodedText = '';
        for (let i = 0; i < text.value.length; i++) {
            let encoded = String.fromCharCode(text.value.charCodeAt(i) + 1);
            encodedText += encoded;
        }
        document.getElementsByTagName('textarea')[1].value = encodedText;
        text.value = '';
    });
    decode.addEventListener('click', function () {
        let text = document.getElementsByTagName('textarea')[1];
        let decodedText = '';
        for (let i = 0; i < text.value.length; i++) {
            let decoded = String.fromCharCode(text.value.charCodeAt(i) - 1);
            decodedText += decoded;
        }
        document.getElementsByTagName('textarea')[1].value = decodedText;
    });
}