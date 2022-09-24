function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let input = document.getElementById('searchField').value.toLowerCase();
      let table = document.querySelectorAll('tbody tr');
      for (const row of table) {
         row.className = '';
      }
      for (const row of table) {
         for (const col of Array.from(row.children)) {
            let text = col.textContent.toLowerCase();
            if (text.includes(input)) {
               row.className = 'select';
               break;
            }
         }
      }
   }
}