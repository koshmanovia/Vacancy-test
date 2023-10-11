<?php
header("Access-Control-Allow-Origin: *"); // Разрешение запросов с любых источников
header("Access-Control-Allow-Methods: POST"); // Разрешение только POST-запросов
header("Access-Control-Allow-Headers: Content-Type"); // Разрешение заголовка Content-Type

if ($_SERVER['REQUEST_METHOD'] === 'POST') 
{
    $json = file_get_contents('php://input');
    $data = json_decode($json, true);

    if (is_array($data)) 
    {
        $result = array();

        // Преобразование массива в желаемый формат
        foreach ($data as $key => $name) 
        {
            $result[$key] = array(
                $name => rand(0, 100)
            );
        }

        // Преобразование результата в JSON
        $jsonResult = json_encode($result);

        // Вывод JSON в ответ
        echo $jsonResult;
    } else 
    {
        echo 'Ошибка: Неверный формат данных';
    }
} 
else 
{
    echo 'Ошибка: Это не POST-запрос';
}
