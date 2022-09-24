function solve() {
  let text = document.getElementById('text').value.toLowerCase().split(' ');
  let namingConvention = document.getElementById('naming-convention').value;
  let resultContainer = document.getElementById('result');
  let result = '';
  for (let i = 0; i < text.length; i++) {
    if (namingConvention == "Camel Case" || namingConvention == "Pascal Case") {
      if (namingConvention == "Camel Case" && i == 0) {
        result += text[i];
        continue;
      }
      text[i] = text[i][0].toUpperCase() + text[i].slice(1);
      result += text[i];
    }
    else {
      result = "Error!";
      break;
    }
  }
  resultContainer.textContent = result;
}