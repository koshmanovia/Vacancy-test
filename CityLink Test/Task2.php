<?php
$list = array (
    '09:00-11:00',
    '11:00-13:00',
    '15:00-16:00',
    '17:00-20:00',
    '20:30-21:30',
    '21:30-22:30',
);
function CheckValidTime(string $subject) : bool
{
    if(preg_match('/([01]?[0-9]|2[0-3]):[0-5][0-9]-([01]?[0-9]|2[0-3]):[0-5][0-9]/', $subject) == 1)
    {
        return true;
    }
    else
    {
        return false;
    }
}
function CheckOverlayTime(string $newTimeInterval) : bool
{
    global $list;
    if(CheckValidTime($newTimeInterval))
    {
        $startNewInterval = ( new DateTime())->setTime((int)substr($newTimeInterval, 0,2),(int)substr($newTimeInterval, 3,2));
        $startNewInterval = $startNewInterval->format('H:i');

        $finishNewInterval = ( new DateTime())->setTime((int)substr($newTimeInterval, 6,2),(int)substr($newTimeInterval, 9,2));
        $finishNewInterval = $finishNewInterval->format('H:i');

        for($i = 0; $i < count($list); $i++ )
        {
            $startArrayInterval = (new DateTime())->setTime((int)substr($list[$i],0,2),(int)substr($list[$i],3,2));
            $startArrayInterval = $startArrayInterval->format('H:i');
            $finishArrayInterval = (new DateTime())->setTime((int)substr($list[$i],6,2),(int)substr($list[$i],9,2));
            $finishArrayInterval = $finishArrayInterval->format('H:i');

            if(strtotime($startNewInterval) < strtotime($finishArrayInterval) and strtotime($finishNewInterval) > strtotime($startArrayInterval))
            {
                return true;
            }
        }
    }
    else
    {
        throw new ErrorException('Input bad format time interval!');
    }
    return false;
}
