using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P0628
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}


//---------------------------------------if else문-----------------------------------------------
/*
int score = 15;

if(score <= 20)
{
    Console.WriteLine("기준 점수를 통과했습니다");
}*/

//시험 점수에 따라 통과 여부 판단 
/*
int score = 55;

if (score >= 60)
{
    Console.WriteLine("합격입니다");
}

else
{
    Console.WriteLine("불합격 입니다");
}*/

//number라는 변수에 6을 할당
//만약에 2로 나눴을 때 나머지가 0이라면( % )
//짝수입니다 출력하기

/*int number = 6;

if (number % 2 == 0)
{
    Console.WriteLine("짝수입니다");
}

else
{
    Console.WriteLine("홀수입니다");
}*/

/*
int score = 70;

if (score >= 90)
{
    Console.WriteLine("A학점 입니다");
}

else if (score >= 80)
{
    Console.WriteLine("B학점 입니다");
}

//else if 를 사용하여 score 70보다 크거나 같다면
//C학점입니다를 출력

else if (score >= 70)
{
    Console.WriteLine("C학점 입니다");
}

else
{
    Console.WriteLine("재시험이 필요합니다");
}*/

//Console.Write("점수를 입력하세요");
//Console.ReadLine() -> 기본적으로 문자열을 입력받게 된다.
//그런데, 지금 우리는 정수를 입력받고 싶다.
//따라서 int.Parse로 문자를 정수로 변환한다.
/*
int score = int.Parse(Console.ReadLine());

if (score >= 60)
{
    Console.WriteLine("합격입니다");
}

else
{
    Console.WriteLine("불합격입니다");
}*/

/*
//HP에 따라 플레이어 상태 출력하기
Console.Write("HP : ");
//HP를 입력 받고
int HP = int.Parse(Console.ReadLine());
//HP가 70보다 크다면 건강함 출력
if (HP > 70)
{
    Console.WriteLine("건강함");
}
//HP가 30보다 크다면 위험함 출력
else if (HP > 30)
{
    Console.WriteLine("위험함");
}
//HP가 0보다 크다면 매우 위급함
else if (HP > 0)
{
    Console.WriteLine("매우 위급함");
}
//HP가 0보다 작거나 같다면 사망
else
{
    Console.WriteLine("사망");
}*/
//---------------------------------------------for문---------------------------------------------------
//i++ = i + 1
//1부터 5까지 출력
/*
for (int i = 1; i <= 5;  i++)
{
    Console.WriteLine(i);
}*/

/*
for (int i = 0; i <= 10; i++)
{
    Console.WriteLine(i);
}*/

//***** (for문을 사용하여 별 5개 출력하기)
/*
for (int i = 0; i <= 5; i++)
{
    Console.Write("*");
}*/

/*
for (int i = 1; i <=10; i+=2)
{
    Console.Write(i);
}*/

/*
for (int i = 1; i < 10; i+=4)
{
    Console.Write(i);
}*/

/*
for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}*/

/*
for(int i = 5; i >= 1; i--)
{
    for(int j = 1; j <= i; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}*/

//***
//**
//*
/*
for(int i = 3; i >= 1; i--)
{
    for(int j = 1; j <= i; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}

//N*N별 사각형 출력하기
Console.Write("크기를 입력해주세요 : ");
//사용자로부터 정수 N을 입력받아,
int s = int.Parse(Console.ReadLine());
//N행 N열의 별(*) 사각형을 출력하세요
for(int i = 0; i < s; i++)
{
    for(int j = 0; j < s; j++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}
// 사용자 입력 : 4
//
//****
//****
//****
//****
*/
/*
for (int i = 1; i <= 9; i++)
{
    Console.Write($"2x{i} = {2 * i} \t");
}*/
//-----------------------------------------문자열 보간법------------------------------------------
//$문자열 보간법
//문자열 안에 변수나 식을 간편하게 삽입할 수 있게 해주는 문법이다.
//문자열 앞에 $를 붙이고, 중괄호 {}에 변수나 식을 넣는다.
/*
int score = 95;
string name = "철수";

//문자열 보간법 사용
string message = $"학생 {name}의 점수는 {score}점 입니다";
Console.WriteLine(score);*/