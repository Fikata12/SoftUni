function create(words) {
   for (const word of words) {
      let div = document.createElement('div');
      let p = document.createElement('p');
      p.textContent = word;
      p.style = 'display:none';
      div.appendChild(p);
      div.addEventListener('click', function(){
         div.getElementsByTagName('p')[0].style = 'display:block';
      });
      document.getElementById('content').appendChild(div);
   }
 }