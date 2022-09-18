function func(inputArray) {
    let array = [...inputArray];
    let dashboard = [[false, false, false],
                     [false, false, false],
                     [false, false, false]];
    let playerSwitch = 'X';
    for (const coordinates of array) {
        let x = Number(coordinates[0]);
        let y = Number(coordinates[2]);
        if (dashboard[x][y] == false) {
            dashboard[x][y] = playerSwitch;
            let sign = '';
            let win = false;
            if (!win) {
                for (let i = 0; i < dashboard.length; i++) {
                    sign = '';
                    for (let j = 0; j < dashboard.length; j++) {
                        if (sign == '' && dashboard[i][j] != false) {
                            sign = dashboard[i][j];
                        }
                        else if (sign === dashboard[i][j]) {
                            win = true;
                        }
                        else {
                            win = false;
                            break;
                        }
                    }
                    if (win) {
                        break;
                    }
                }
            }
            if (!win) {
                for (let i = 0; i < dashboard.length; i++) {
                    sign = '';
                    for (let j = 0; j < dashboard.length; j++) {
                        if (sign == '' && dashboard[j][i] != false) {
                            sign = dashboard[j][i];
                        }
                        else if (sign === dashboard[j][i]) {
                            win = true;
                        }
                        else {
                            win = false;
                            break;
                        }
                    }
                    if (win) {
                        break;
                    }
                }
            }
            if (!win) {
                let areEqual = dashboard[0][0] == dashboard[1][1] && dashboard[0][0] == dashboard[2][2] && dashboard[0][0] !== false;
                if (areEqual) {
                    win = true;
                }
            }
            if (!win) {
                let areEqual = dashboard[0][2] == dashboard[1][1] && dashboard[0][2] == dashboard[2][0] && dashboard[0][2] !== false;
                if (areEqual) {
                    win = true;
                }
            }
            if (win) {
                console.log(`Player ${playerSwitch} wins!`);
                break;
            }
            else {
                let isFull = true;
                for (const item of dashboard) {
                    if (item.includes(false)) {
                        isFull = false;
                        break;
                    }
                }
                if (isFull) {
                    console.log("The game ended! Nobody wins :(");
                    break;
                }
            }
            if (playerSwitch == 'X') {
                playerSwitch = 'O';
            } else {
                playerSwitch = 'X';
            }
        }
        else {
            console.log("This place is already taken. Please choose another!");
            if (playerSwitch == 'X') {
                playerSwitch = 'X';
            } else {
                playerSwitch = 'O';
            }
        }
    }
    for (const item of dashboard) {
        console.log(item.join('\t'));
    }
}