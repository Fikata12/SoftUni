function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let input = document.getElementsByTagName('textarea')[0].value.split('","');
      input[0] = input[0].substring(2);
      input[input.length - 1] = input[input.length - 1].substring(0, input[input.length - 1].length - 2);
      let allRestaurants = [];
      for (const item of input) {
         let nameAndWorkers = item.split(' - ');
         let name = nameAndWorkers[0];

         let workersData = nameAndWorkers[1].split(', ');
         let workers = [];
         for (const item of workersData) {
            workers.push({ name: item.split(' ')[0], salary: Number(item.split(' ')[1]) });
         }

         let currentBestSalary = 0;
         let currentAverageSalary = 0;
         for (const worker of workers) {
            currentAverageSalary += worker.salary;
            if (worker.salary > currentBestSalary) {
               currentBestSalary = worker.salary;
            }
         }
         currentAverageSalary /= workers.length;

         let currentRestaurant = allRestaurants.find(r => r.name == name);
         if (allRestaurants.includes(currentRestaurant)) {
            currentRestaurant.averageSalary = (currentAverageSalary * workers.length +
               currentRestaurant.averageSalary * currentRestaurant.workers.length) / (workers.length + currentRestaurant.workers.length);

            currentRestaurant.bestSalary = (currentRestaurant.bestSalary >= currentBestSalary) ? currentRestaurant.bestSalary : currentBestSalary;
            currentRestaurant.workers.push(...workers);
         }
         else {
            allRestaurants.push({
               name: name, workers: workers,
               averageSalary: currentAverageSalary,
               bestSalary: currentBestSalary
            });
         }
      }
      
      let highestAverageSalary = 0;
      for (const restaurant of allRestaurants) {
         if (restaurant.averageSalary > highestAverageSalary) {
            highestAverageSalary = restaurant.averageSalary;
         }
      }

      let bestRestaurant = allRestaurants.find(r => r.averageSalary == highestAverageSalary);
      let bestRestaurantBox = document.getElementById('bestRestaurant').querySelector('p');
      let workersBox = document.getElementById('workers').querySelector('p');
      bestRestaurantBox.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;
      bestRestaurant.workers.sort((a, b) => b.salary - a.salary).forEach(w => {
         workersBox.textContent += `Name: ${w.name} With Salary: ${w.salary} `;
      });
   }
}