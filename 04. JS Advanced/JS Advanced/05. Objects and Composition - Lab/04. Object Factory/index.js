function func(library, orders) {
    let result = [];
    for (const order of orders) {
        for (const part of order.parts) {
            order.template[part] = library[part];
        }
        result.push(order.template);
    }
    return result;
}