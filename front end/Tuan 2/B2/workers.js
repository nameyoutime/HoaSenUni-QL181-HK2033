let temp = self.addEventListener('message', function (e) {
  let numb1 = parseInt(e.data[0]);
  let numb2 = parseInt(e.data[1]);
  let t = numb1 + numb2;
  postMessage(t);
  setInterval(() => {
    t = t + numb2;
    postMessage(t);
  }, 5000);

}, false);
