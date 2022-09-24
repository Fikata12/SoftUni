function search() {
   let towns = document.querySelectorAll('ul#towns li');
   let searchBox = document.getElementById('searchText').value.toLowerCase();
   let result = document.getElementById('result');
   for (const town of towns) {
      town.style = "text-decoration: none; font-weight: none";
   }
   let counter = 0;
   for (const town of towns) {
      let text = town.textContent.toLowerCase();
      if (text.includes(searchBox)) {
         town.style = "text-decoration: underline; font-weight: bold";
         counter++;
      }
   }
   result.textContent = `${counter} matches found`;
}
