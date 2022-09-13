function Cooking(num, cmd1, cmd2, cmd3, cmd4, cmd5) {
    let allCommands = [cmd1, cmd2, cmd3, cmd4, cmd5];
    allCommands.forEach(element => {
        switch (element) {
            case 'chop':
                num /= 2;
                break;
            case 'dice':
                num = Math.sqrt(num);
                break;
            case 'spice':
                num += 1;
                break;
            case 'bake':
                num *= 3;
                break;
            case 'fillet':
                num -= 0.2 * num;
                break;
        }
        console.log(num);
    });
}