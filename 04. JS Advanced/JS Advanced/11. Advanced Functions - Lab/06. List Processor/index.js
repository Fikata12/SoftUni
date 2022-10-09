function solve(commandSets) {
    let engine1 = engine();
    for (const commandSet of commandSets) {
        let command = commandSet.split(' ')[0];
        let arg = commandSet.split(' ')[1];
        engine1[command](arg);   
    }
    function engine() {
        let list = [];
        return {
            add: function (string) {
                list.push(string);
            },
            remove: function (string) {
                let i = list.length;
                while (i--) {
                    if (list[i] === string) {
                        list.splice(list.indexOf(string), 1);
                    }
                }
            },
            print: function () {
                console.log(list.join(','));
            }
        };
    }
}