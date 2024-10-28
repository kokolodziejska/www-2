document.addEventListener('DOMContentLoaded', () => {
    displayQuotes();
});

function getQuotesFromStorage() {
    return JSON.parse(localStorage.getItem('quotes')) || [];
}

function saveQuotesToStorage(quotes) {
    localStorage.setItem('quotes', JSON.stringify(quotes));
}

function displayQuotes() {
    const quotesList = document.getElementById('quotesList');
    quotesList.innerHTML = '';

    const quotes = getQuotesFromStorage();
    quotes.forEach((quote, index) => {
        const li = document.createElement('li');
        li.className = 'quote-item';

        const span = document.createElement('span');
        span.textContent = quote;
        li.appendChild(span);

        const editButton = document.createElement('button');
        editButton.textContent = 'Edytuj';
        editButton.onclick = () => editQuote(index);
        li.appendChild(editButton);

        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Usuń';
        deleteButton.onclick = () => deleteQuote(index);
        li.appendChild(deleteButton);

        quotesList.appendChild(li);
    });
}

function addQuote() {
    const quoteInput = document.getElementById('quoteInput');
    const quoteText = quoteInput.value.trim();
    if (quoteText) {
        const quotes = getQuotesFromStorage();
        quotes.push(quoteText);
        saveQuotesToStorage(quotes);
        displayQuotes();
        quoteInput.value = '';
    }
}

function deleteQuote(index) {
    const quotes = getQuotesFromStorage();
    quotes.splice(index, 1);
    saveQuotesToStorage(quotes);
    displayQuotes();
}

function editQuote(index) {
    const quotes = getQuotesFromStorage();
    const newQuote = prompt("Edytuj cytat:", quotes[index]);
    if (newQuote !== null) {
        quotes[index] = newQuote.trim();
        saveQuotesToStorage(quotes);
        displayQuotes();
    }
}
