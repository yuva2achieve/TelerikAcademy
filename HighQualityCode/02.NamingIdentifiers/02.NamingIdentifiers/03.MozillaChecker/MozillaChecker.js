function onButtonClick(event, args) {
  var currentWindow = window;
  var currentBrowser = currentWindow.navigator.appCodeName;
  var isMozilla = false;
  if (currentBrowser === "Mozilla") {
  	isMozilla = true;
  }
  if (isMozilla) {
    alert("Yes");
  } else {
    alert("No");
  }
}
