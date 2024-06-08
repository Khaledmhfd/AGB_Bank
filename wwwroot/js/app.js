//    /* Created by Tivotal */
//let dropList = document.querySelectorAll("form select");
//let fromCurrency = document.querySelector(".from select");
//let toCurrency = document.querySelector(".to select");
//let icon = document.querySelector(".icon");
//let exchangeTxt = document.querySelector(".exchange_rate");
//let getBtn = document.querySelector("button");



////adding options tag

//for (let i = 0; i < dropList.length; i++) {
//    for (let currency_code in country_list) {
//        let selected =
//            i == 0
//                ? currency_code == "EUR"
//                    ? "selected"
//                    : ""
//                : currency_code == "DZD"
//                    ? "selected"
//                    : "";

//        let optionTag = `<option value="${currency_code}" ${selected}>
//    ${currency_code}</option>`;

//        dropList[i].insertAdjacentHTML("beforeend", optionTag);
//    }

//    dropList[i].addEventListener("change", (e) => {
//        loadFlag(e.target);
//        getExchangeValue();
//    });
//}

//function loadFlag(element) {
//    for (let code in country_list) {
//        if (code == element.value) {
//            let imgTag = element.parentElement.querySelector("img");
//            imgTag.src = `https://flagcdn.com/48x36/${country_list[
//                code
//            ].toLowerCase()}.png`;
//        }
//    }
//}

//function getExchangeValue() {
//    const amount = document.querySelector("form input");
//    let amountVal = amount.value;
//    if (amountVal == "" || amountVal == "0") {
//        amount.value = "1";
//        amountVal = 1;
//    }

//    exchangeTxt.innerText = "Getting exchange rate...";
//    let url = `https://v6.exchangerate-api.com/v6/876bee577712406525d51a6c/latest/${fromCurrency.value}`;
//    fetch(url)
//        .then((response) => response.json())
//        .then((result) => {
//            let exchangeRate = result.conversion_rates[toCurrency.value];
//            let total = (amountVal * exchangeRate).toFixed(2);
//            exchangeTxt.innerText = `${amountVal} ${fromCurrency.value} = ${total} ${toCurrency.value}`;
//        })
//        .catch(() => {
//            exchangeTxt.innerText = "something went wrong";
//        });
//}

//window.addEventListener("load", () => {
//    getExchangeValue();
//});

//getBtn.addEventListener("click", (e) => {
//    e.preventDefault();
//    getExchangeValue();
//});

//icon.addEventListener("click", () => {
//    let tempCode = fromCurrency.value;
//    fromCurrency.value = toCurrency.value;
//    toCurrency.value = tempCode;
//    loadFlag(fromCurrency);
//    loadFlag(toCurrency);
//    getExchangeValue();
//});

let dropList = document.querySelectorAll("form select");
let fromCurrency = document.querySelector(".from select");
let toCurrency = document.querySelector(".to select");
let icon = document.querySelector(".icon");
let exchangeTxt = document.querySelector(".exchange_rate");
let getBtn = document.querySelector("button");

// Adding options to select elements
for (let i = 0; i < dropList.length; i++) {
    for (let currency_code in country_list) {
        let selected =
            i == 0
                ? currency_code == "EUR"
                    ? "selected"
                    : ""
                : currency_code == "DZD"
                    ? "selected"
                    : "";
        let optionTag = `<option value="${currency_code}" ${selected}>${currency_code}</option>`;
        dropList[i].insertAdjacentHTML("beforeend", optionTag);
    }
    dropList[i].addEventListener("change", (e) => {
        loadFlag(e.target);
        getExchangeValue();
    });
}

function loadFlag(element) {
    for (let code in country_list) {
        if (code == element.value) {
            let imgTag = element.parentElement.querySelector("img");
            imgTag.src = `https://flagcdn.com/48x36/${country_list[code].toLowerCase()}.png`;
        }
    }
}

getBtn.addEventListener("click", (e) => {
    e.preventDefault(); // Prevent the form from submitting
    getExchangeValue();
});

function getExchangeValue() {
    const amount = document.querySelector("form input");
    let amountVal = amount.value;
    if (amountVal == "" || amountVal == "0") {
        amount.value = "1";
        amountVal = 1;
    }

    exchangeTxt.innerText = "Getting exchange rate...";
    let url = `https://v6.exchangerate-api.com/v6/876bee577712406525d51a6c/latest/${fromCurrency.value}`;
    fetch(url)
        .then((response) => response.json())
        .then((result) => {
            let exchangeRate = result.conversion_rates[toCurrency.value];
            let total = (amountVal * exchangeRate).toFixed(2);
            exchangeTxt.innerHTML = `${amountVal} <span>${fromCurrency.value}</span> = ${total}<span> ${toCurrency.value}</span>`;
        })
        .catch(() => {
            exchangeTxt.innerText = "Il y a eu un probl�me.";
        });
}

window.addEventListener("load", () => {
    getExchangeValue();
});

//icon.addEventListener("click", () => {
//    let tempCode = fromCurrency.value;
//    fromCurrency.value = toCurrency.value;
//    toCurrency.value = tempCode;
//    loadFlag(fromCurrency);
//    loadFlag(toCurrency);
//    getExchangeValue();
//});
