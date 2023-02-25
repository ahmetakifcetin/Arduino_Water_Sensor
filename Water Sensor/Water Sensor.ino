
int seviye=A0;
int kirmizi=8;
int yesil=9;
int mavi=10;

void setup(){
pinMode(kirmizi,OUTPUT);
pinMode(yesil,OUTPUT);
pinMode(mavi,OUTPUT);
Serial.begin(9600);}

void loop() {
seviye=analogRead(A0);
Serial.println(seviye);

if(seviye < 100){
digitalWrite(kirmizi,HIGH);
digitalWrite(yesil,LOW);
digitalWrite(mavi,LOW);}
delay(500);
if(seviye > 150 && seviye <= 300){
digitalWrite(kirmizi,HIGH);
digitalWrite(yesil,HIGH);
digitalWrite(mavi,LOW);}

if(seviye > 500){
digitalWrite(kirmizi,HIGH);
digitalWrite(yesil,HIGH);
digitalWrite(mavi,HIGH);}
}
