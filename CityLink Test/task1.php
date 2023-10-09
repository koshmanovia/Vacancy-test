<?php
$areas = array (
    1 => '5-й поселок',
    2 => 'Голиковка',
    3 => 'Древлянка',
    4 => 'Заводская',
    5 => 'Зарека',
    6 => 'Ключевая',
    7 => 'Кукковка',
    8 => 'Новый сайнаволок',
    9 => 'Октябрьский',
    10 => 'Первомайский',
    11 => 'Перевалка',
    12 => 'Сулажгора',
    13 => 'Университетский городок',
    14 => 'Центр',
);
$nearby = array (
    1 => array(2,11),
    2 => array(12,3,6,8),
    3 => array(11,13),
    4 => array(10,9,13),
    5 => array(2,6,7,8),
    6 => array(10,2,7,8),
    7 => array(2,6,8),
    8 => array(6,2,7,12),
    9 => array(10,14),
    10 => array(9,14,12),
    11 => array(13,1,9),
    12 => array(1,10),
    13 => array(11,1,8),
    14 => array(9,10),
);
$workers = array (
    0 => array (
        'login' => 'login1',
        'area_name' => 'Октябрьский', //9
    ),
    1 => array (
        'login' => 'login2',
        'area_name' => 'Зарека', //5
    ),
    2 => array (
        'login' => 'login3',
        'area_name' => 'Сулажгора', //12
    ),
    3 => array (
        'login' => 'login4',
        'area_name' => 'Древлянка', //3
    ),
    4 => array (
        'login' => 'login5',
        'area_name' => 'Центр', //14
    ),
);
function GetWorker(string $inputDist) : ?string
{
    global $areas;
    global $nearby;
    global $workers;
    $workerName = null;

    $numInputDist = Array_search($inputDist, $areas); // получаем индекс в массиве переданного района

    //проходим по массиву $nearby и выделяем отдельный массив $nearDist
    foreach($nearby as $nearDist)
    {
        //проверяем есть ли в массиве $nearDist номер района переданного в функцию
        if(in_array($numInputDist,$nearDist))
        {
            //проходим по массиву работников и смотрим соответсвие
            foreach($workers as $worker)
            {
                //при прямом соответствии сразу завершаем цикл, и отдаем значение
              if($numInputDist == Array_search($worker['area_name'],$areas))
              {
                  return $worker['login'];
              }
		        //если работник найден в соседнем районе, запомнить во временную переменную
              elseif(in_array(Array_search($worker['area_name'],$areas), $nearDist))
              {
                  $workerName = $worker['login'];
              }
            }
        }
    }
    return $workerName;
}
