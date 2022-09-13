function wordsUppercase(arg){
     let text = String(arg);
    return text.match(/\w+/g).join(', ').toUpperCase();
}