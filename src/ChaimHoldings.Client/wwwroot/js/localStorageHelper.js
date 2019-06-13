window.localStorageHelper = {};

localStorageHelper.setItem = function (key, value) {
    localStorage.setItem(key, value);
};

localStorageHelper.getItem = function (key) {
    return localStorage.getItem(key);
};