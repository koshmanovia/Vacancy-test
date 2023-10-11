var indexView = "";
var separator = ",";
var input = document.querySelector('input');
var button = document.querySelector('button');
var tempArray = [];
var headErrorIncorrectData = "Ошибка ввода!";
var bodyErrorIncorrectData = "Введите имена кириллицей, через запятую.";
var bodyErrorEmptyData = "Пустое поле ввода! Необходимо внести данные"
var fullTable = '';
var url = 'http://localhost:3000';
//Вывод основной верстки
window.onload = function() 
{
    indexView += 
    '<div class="container" >' +
      '<div class="row">'+
        '<div class="col-md-8 mx-auto text-center">'+
          '<h2>Олимпиада</h2>'+
        '</div>'+
      '</div>'+
    '</div>'+
    '<div class="card">'+
        '<div class="card-body">'+
         '<h5 class="card-title">Участники</h5>'+
          '<p class="card-text">введите имена участников через запятую.</p>'+
          '<input type="text" name="name" /><br />'+
          '<p> </p>'+
          '<button class="btn btn-primary" type="button" onclick="ManipulationInputData ()">Добавить</button>'+
        '</div>'+
      '</div>';
    document.body.innerHTML = indexView ;
}
//Нажатие кнопки по нажатию ENTER
document.addEventListener('keydown', enter);
function enter(e)
{
    if(e.code === 'Enter' || e.code ===  'NumpadEnter')
    {
        ManipulationInputData ();        
    }
}
//обработка вводимых данных
function ManipulationInputData ()
{
    let input = document.querySelector('input').value
    if(input)
    {
        if (/^[,а-яА-ЯёЁ\s]+$/.test(input))
        {
            let arrWords = input.split(separator);
            tempArray =tempArray.concat(arrWords);
            SendPostRequest();
            document.querySelector('input').value = '';
            ViewTableFromInput();
        }
        else 
        {    
        ErrorWindow(headErrorIncorrectData, bodyErrorIncorrectData);
        }
    }
    else 
    { 
        ErrorWindow(headErrorIncorrectData, bodyErrorEmptyData);
    } 
}

function SendPostRequest() 
{
    fetch(url, 
    {
        method: 'POST',
        headers: 
        {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(tempArray)
    })
        .then(response => response.json())
        .then(data => 
        {
            ViewTableFromInput(data);
        })
        .catch(error => {
            console.error('Произошла ошибка:', error);
        });
}
//Отображение таблицы
function ViewTableFromInput(data) {
    let tableStart = '<table class="table" id="sortable"><thead><tr><th scope="col" data-type="number">№</th>' +
        '<th scope="col" data-type="string">Имя</th><th scope="col" data-type="number">Очки</th></tr></thead>';
    let tableFinish = '</table>';
    let list = '';

    // Перебор данных и создание строк таблицы
    for (let key in data) {
        if (data.hasOwnProperty(key)) {
            let name = Object.keys(data[key])[0]; // Получить имя из объекта
            let points = data[key][name]; // Получить количество очков

            list += '<tr><th scope="row">' + (parseInt(key) + 1) + '</th>' +
                '<td>' + name + '</td>' +
                '<td>' + points + '</td>' + '</tr>';
        }
    }

    let fullTable = tableStart + '<tbody>' + list + '</tbody>' + tableFinish;
    document.body.innerHTML = indexView + fullTable;
}

//Окно ошибки 
function ErrorWindow(headErrorIncorrectData, bodyErrorIncorrectData)
{
    document.body.innerHTML = indexView +
    '<div class="modal fade" id="modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">' +
  '<div class="modal-dialog">' +
    '<div class="modal-content">' +
      '<div class="modal-header">' +
        '<h5 class="modal-title">'+ headErrorIncorrectData +'</h5>' +
       '<button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>' +
      '</div>' +
      '<div class="modal-body">' +
        '<p>'+bodyErrorIncorrectData+'</p>' +
      '</div>' +
      '<div class="modal-footer">' +
        '<button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Закрыть</button>' +        
      '</div>' +
    '</div>' +
  '</div>' +
'</div>' + fullTable;
  const modal = new bootstrap.Modal(document.querySelector('#modal'));
  modal.show();
}