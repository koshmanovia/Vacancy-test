<?php
interface IMoverFirm
{
    public function GetName(): string;

    public function GetSum(int $wiegh): float;
}
class DHL implements IMoverFirm
{
    static function GetName()
    {
        return 'DHL';
    }
    static function GetSum(int $wiegh)
    {
        return $wiegh * 100;
    }
}
class RussiaPost implements IMoverFirm
{
    static function GetName()
    {
        return 'RussiaPost';
    }
    static function GetSum(int $wiegh)
    {
        If($wiegh < 10)
        {
            return 100;
        }
        else
        {
            return 1000;
        }

    }
}
