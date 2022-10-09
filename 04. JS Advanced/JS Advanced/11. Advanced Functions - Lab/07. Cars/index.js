function solve(input) {
    let data = [];
    let engine = carsManipulator();
    for (const task of input) {
        let [cmd, name, key, value] = task.split(' ');
        if (key == 'inherit') {
            cmd += key;
            key = value;
        }
        engine[cmd](name, key, value);
    }
    function carsManipulator() {
        return {
            create: (name) => {
                data[name] = {};
            },
            createInherit: (name, nameOfParent) => {
                let newObj = Object.create(data[nameOfParent]);
                data[name] = newObj;
            },
            set: (name, key, value) => {
                data[name][key] = value;
            },
            print: (name) => {
                let output = [];
                for (var prop in data[name]) {
                    output.push(`${prop}:${data[name][prop]}`);
                }
                console.log(output.join(','));
            }
        };
    }
}