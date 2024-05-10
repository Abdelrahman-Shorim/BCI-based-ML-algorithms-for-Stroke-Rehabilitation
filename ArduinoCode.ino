#define directionpinR 2
#define steppinR 3

#define directionpinL 4
#define steppinL 5
#define stepsperrevolution 1600


void setup() {
  Serial.begin(9600);
  pinMode(directionpinR, OUTPUT);
  pinMode(steppinR, OUTPUT);
  pinMode(directionpinL, OUTPUT);
  pinMode(steppinL, OUTPUT);
}

void loop() {
  if (Serial.available()) {
    char c = Serial.read();
    Serial.write(c);
    if(c=='r'){
      rightMotor();
      }
    else if(c=='l'){
      leftMotor();
    }
  }

}

void rightMotor(){
  for(int i =0; i< 2*stepsperrevolution;i++){
    digitalWrite(directionpinR, HIGH);
    digitalWrite(steppinR,HIGH);
    delayMicroseconds(50);
    digitalWrite(steppinR, LOW);
    delayMicroseconds(50);
  }

  delay(2000);

  for(int i =0; i< 2*stepsperrevolution;i++){
    digitalWrite(directionpinR, LOW);
    digitalWrite(steppinR,HIGH);
    delayMicroseconds(50);
    digitalWrite(steppinR, LOW);
    delayMicroseconds(50);
  }
}

void leftMotor(){
  for(int i =0; i< 2*stepsperrevolution;i++){
    digitalWrite(directionpinL, HIGH);
    digitalWrite(steppinL,HIGH);
    delayMicroseconds(50);
    digitalWrite(steppinL, LOW);
    delayMicroseconds(50);
  }

  delay(2000);

  for(int i =0; i< 2*stepsperrevolution;i++){
    digitalWrite(directionpinL, LOW);
    digitalWrite(steppinL,HIGH);
    delayMicroseconds(50);
    digitalWrite(steppinL, LOW);
    delayMicroseconds(50);
  }
}