function solve(ticketsInput, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }
    let tickets = ticketsInput.map(e => new Ticket(...e.split('|')));
    switch (criteria) {
        case 'destination':
        case 'status':
            tickets.sort((a, b) => a[criteria].localeCompare(b[criteria]));
            break;
        case 'price':
            tickets.sort((a, b) => a.price - b.price);
            break;
        default:
            break;
    }
    return tickets;
}