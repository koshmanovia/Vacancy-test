var indexView = "";
var separator = ",";
var input = document.querySelector('input');
var button = document.querySelector('button');
var tempArray = [];
var headErrorIncorrectData = "Ошибка ввода!";
var bodyErrorIncorrectData = "Введите имена кириллицей, через запятую.";
var bodyErrorEmptyData = "Пустое поле ввода! Необходимо внести данные"
var fullTable = '';
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
//Отображение таблицы
function ViewTableFromInput()
{
    let tableStart ='<table class="table" id="sortable"><thead><tr><th scope="col" data-type="number">№</th>' + 
        '<th scope="col" data-type="string" >Имя</th><th scope="col" data-type="number">Очки</th></tr></thead>' ;
    let tableFinish = '</table>';
    let list = '';
    for(let i = 0; i < tempArray.length; i++ )
    {
        if (tempArray[i]!= ' ' && tempArray[i]!= '')
        { 
            list+= '<tr><th scope="row">' + (i + 1) + '</th>' + '<td>' + tempArray[i] + '</td>' + '<td>' + Math.floor(Math.random()* 101) + '</td>' + '</tr>';
        }
    }
    fullTable = tableStart + '<tbody>' + list + '</tbody>' + tableFinish;
    document.body.innerHTML = indexView +  fullTable;    
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