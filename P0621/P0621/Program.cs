using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Using : 필요한 기능들을 가져오는 것
// 예를 들어 Console.WriteLine()을 사용하려면 Systemd라는 기능 집합이 필요하다.
// 이를 위해 using지시문에 System을 적는다.

// 코드를 구분짓는 이름표 같은 것
// 내가 만든 코드랑 다른 사람이 만든 코드가 겹치지 않도록 해주는 기능이다.
namespace P0621
{
    // 코드를 묶는 틀 또는 설계도
    internal class Program
    {
        // 실제 코드를 실행하는 함수
        static void Main(string[] args)
        {


            //소숫점 에제
            //*******float을 쓸 때는 변수값 뒤에 f를 무조건 붙여하한다.********//
            //float height = 190.5f;

            //결과값
            //키 : 190.5cm
            //Console.WriteLine("키 : " + height + "cm");

            //소숫점 예제
            //변수명 key
            //변수 값 : 13.5
            //결과 값 : key는 13.5입니다.

            //float key = 13.5f;
            //Console.WriteLine("key는 " + key + "입니다.");

            //글자 예제
            //변수명 : name
            //변수값 : 슈퍼마리오
            //문법
            //string "큰 따옴표 사용"

            //string name = "슈퍼마리오";
            //Console.WriteLine(name);

            //변수 이름 짓는 규칙(C#기준)
            //1. 영어 또는 _로 시작해야한다 ex) name, _count
            //2. 숫자로 시작하면 안돼요      ex) name01(o), 01name(x)
            //3. 띄어쓰기 안돼요.  ex) n a m e (x)
            //4. 특수문자 안돼요.  ex) name* (x)       (_언더바만 사용가능)
            //5. 대소문자 구분한다. ex) Score, score (이 두개는 다른거다)
            //6. 예약어가 안돼요   ex) int, float

            //string name = "홍길동";
            //Console.WriteLine(name);

            //자료형 int, float, string, bool, char

            //bool 참 거짓
            //bool monster = false;
            //Console.WriteLine(monster);

            //학생인가요?
            //카멜 표기법 : 단어 첫글자는 소문자, 두번째부터 대문자
            //bool isStudent = false;
            //Console.WriteLine("학생인가요? " + isStudent);

            //char자료형(문자 1개 출력)
            //char는 작은따옴표를 사용한다.
            //char grade = 'A';
            //Console.WriteLine("성적 : " + grade);

            //char name_1 = '가';
            //Console.WriteLine(name_1);

            /*
            //1. 정수
            int age = 15;
            //2. 실수
            float height = 163.5f;
            //3. 글자
            string name = "지민";
            //4. 참/거짓
            bool Student = true;
            //5. 문자 1개
            char grade = 'A';

            Console.WriteLine("나이: " + age + "살");
            Console.WriteLine("키: " + height);
            Console.WriteLine("이름: " + name);
            Console.WriteLine("학생인가요? " + Student);
            Console.WriteLine("성적 등급: " + grade);*/

            /*
            //+ : 더하기
            //- : 뺴기
            //* : 곱하기
            // / : 나누기
            // % : 나머지

            int a = 10;
            int b = 3;

            //더하기
            Console.WriteLine(a + b);
            //빼기
            Console.WriteLine(a - b);
            //곱하기
            Console.WriteLine(a * b);
            //나누기
            Console.WriteLine(a / b);
            //나머지
            Console.WriteLine(a % b);*/

            //비교 연산자(맞는지 확인할 때)

            // =    : 대입한다. 할당한다. (값을 넣을 때 사용한다)
            // ==   : 같다
            // !=   : 다르다
            // >    : 크다
            // <    : 작다
            // >=   : 크거나 같다
            // <=   : 작거나 같다

            //예제1 : 두 숫자가 같은지 비교(!=, ==)
            //int c = 10;
            //int d = 5;

            //Console.WriteLine("c == d : " + (c == d)); //false
            //Console.WriteLine("c != d : " + (c != d)); //true

            //나이 비교
            //int age = 16;

            //Console.WriteLine("성인인가요? " + (age >= 20));
            //Console.WriteLine("성인이 아닌가요? " + (age <= 20));

            //입력하기
            //문법
            //Console.ReadLine();

            //출력
            //Console.WriteLine();
            //입력
            //Console.ReadLine();
            //이건 항상 string(문자) 형태로 입력값을 받는다.

            //이름 입력받기 예제
            //Console.WriteLine("이름을 입력하세요 : ");
            //string name = Console.ReadLine();
            //Console.WriteLine("안녕하세요." + name + "님!");

            //좋아하는 음식 묻기
            //Console.WriteLine("좋아하는 음식을 입력하세요 : ");
            //string food = Console.ReadLine();
            //Console.WriteLine("당신의 좋아하는 음식은 " + food + "군요!");

            //숫자 입력받기
            //문자 -> 숫자
            //문법 : int.pe

            //나이를 입력받기
            //Console.WriteLine("나이를 입력하세요");
            //int age = int.Parse(Console.ReadLine());
            //Console.WriteLine("당신은 " + age + "살 입니다");

            /*
            //미션!
            //두 숫자를 입력 받아 더하기
            //힌트는 두개의 변수를 만들고 값을 더하여 출력하시오

            Console.WriteLine("값을 입력해주세요 : ");
            //변수 A 만들고
            int A;
            // A 입력 받고
            A = int.Parse(Console.ReadLine());

            //변수 B 만들고
            int B;
            // B 입력 받고
            B = int.Parse(Console.ReadLine());

            //출력 ("두 수의 합 :" + (A + B);
            Console.WriteLine("두 수의 합 :" + (A + B));

            //A : 5, B = 3  = 두 수의 합 : 8*/

            //사용자 입력값 비교하기
            Console.WriteLine("숫자 하나 입력하세요");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("압력한 숫자가 0보다 큰가요?" + (number > 0));
            Console.WriteLine("짝수인가요?" + (number % 2  == 0));
            //홀수 인가요?
            Console.WriteLine("홀수인가요?" + (number % 2 != 0));

            //논리 연산자(조건 여러 개 붙일 떄)
            // &&(And) 그리고 (둘 다 조건이 참일 떄)
            // !(Not) 반대(아니다)

            int _age = 15;

            //청소년인지 확인(13세 이상이고 19세 이하)
            bool isTeen = _age >= 13 && _age <= 19;
            Console.WriteLine("청소년 인가요?" + isTeen);

            //청소년 인지 아닌지 확인
            bool notTeen = !isTeen;
            Console.WriteLine("청소년이 아닌가요?" + notTeen);

            bool isChild = _age < 13 || _age > 19;//어린이 인지 확인(13세 미만 또는 19세 초과)
            Console.WriteLine("어린이 인가요?" + isChild);

            //미션!(5분)
            //사용자에게 안내 문구 출력
            int score;
            Console.WriteLine("점수를 입력해주세요");
            //사용자가 입력한 값을 정수로 바꿔서 score라는 변수에 저장
            //60점 이상이면 합격(true) 아니면 불합격(false)
            //합격 여부 출력
        }
    }
}

/*
//출력문 : 컴퓨터가 사용자에게 정보를 보여주는 문장이다.
Console.WriteLine("Hello");

//안녕하세요
Console.WriteLine("안녕하세요");

//출력문 종류
//Console.WriteLine() : 한줄 출력하고 자동으로 줄바꿈까지
//Console.Write() : 출력은 하지만 줄바꿈을 하지 않음
Console.Write("안녕");
Console.Write("하세요");

//그냥 줄바꿈
Console.WriteLine();*/


// ------------------------출력문 예제----------------------------
/*
Console.WriteLine("안녕하세요");
Console.WriteLine("반갑습니다");

Console.Write("이름");
Console.Write(": 홍길동");

Console.WriteLine();
Console.Write("나이: ");
Console.WriteLine("20");*/

//-----------------------------변수-----------------------------------
//2차시 변수
//값을 저장하는 상자
//컴퓨터는 모든걸 기억하지 않기 떄문에, 뭔가를 저장해두려면 변수에 넣어야한다.
//변수 : 상자
//변수명 : 상자의 이름표
//변수 값 : 상자 안의 물건

//변수 예시 : 치킨 상자
//변수명 : 비비큐치킨
//변수값 : 치킨

//----------------------------문법---------------------------------
//문법
// 자료형 변수이름 = 값;

//자료형 : 변수(상자)의 크기
//자료형 : 컴퓨터가 어떤 종류의 값을 다루는지 알려주는 표시
//피자 => 박스 커야함 (4호)
//치킨 => 박스 작아도 괜찮(2호)
//에어팟 => 박스 많이 작아도 괜찮(1호)

//문법(외워야한다.)        담을 수 있는 물건 예시
//숫자       : int        =>숫자(정수) 1,2,3,4,5......
//글자       : string     =>안녕하세요.
//참/ 거짓   : bool       => true/ flase
//소수점     : float      => 3.14, 3.15.....
//한글자     : char       => a, b, c

//---------------------------예제1 숫자 예제--------------------------
//예제1 : 숫자 변수
// 자료형 변수이름 = 값;
//변수 선언 및 할당
//int score = 5;
//Console.WriteLine(score);

//변수 이름은 price
//변수 값은 1000
//자료형은 숫자
//변수를 이용하여 1000을 출력하시오
//변수 이름은 겹치지 않게 사용한다.
//int price = 1000;
//Console.WriteLine(price);

//-------------------------------예제2 정수 예제-----------------------
//정수 예제
//int age = 20;
//나이 : 20살
//+는 글자와 글자를 연결할 수 있다
//Console.WriteLine("나이 : " + age + "살");