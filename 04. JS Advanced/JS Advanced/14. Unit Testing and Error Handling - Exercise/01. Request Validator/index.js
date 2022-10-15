function solve(obj) {
    let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let validUri = /^[\w.]+$|^[*{0,1}]$/;
    let validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let validMessage = /^[^<>\\&'"]*$/;
    if (!validMethods.includes(obj['method'])) {
        throw Error("Invalid request header: Invalid Method");
    }
    if (obj['uri'] === undefined || !validUri.test(obj['uri'])) {
        throw Error("Invalid request header: Invalid URI");
    }
    if (!validVersions.includes(obj['version'])) {
        throw Error("Invalid request header: Invalid Version");
    }
    if (obj['message'] === undefined || !validMessage.test(obj['message'])) {
        throw Error("Invalid request header: Invalid Message");
    }
    return obj;
}