const http = require('http');

function sameTotal(a, b) {
  debugger;
  return a == b;
}

http.createServer((req, res) => {
  res.setHeader('Access-Control-Allow-Origin', '*');
  res.end(String(sameTotal(1, 1)));
}).listen(8080);
