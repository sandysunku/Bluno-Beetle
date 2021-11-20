/* 
 *  Bluetooh Basic: LED ON OFF
 *  Coder - Sandeep Sunku
 */
char Incoming_value = 0;                //Variable for storing Incoming_value
void setup() 
{
  Serial.begin(115200);         //Sets the data rate in bits per second (baud) for serial data transmission
  pinMode(2, OUTPUT);        //Sets digital pin 2 as output pin
}
void loop()
{
  if(Serial.available() > 0)  
  {
    Incoming_value = Serial.read();      //Read the incoming data and store it into variable Incoming_value
    Serial.print(Incoming_value);        //Print Value of Incoming_value in Serial monitor
    Serial.print("\n");        //New line 
    if(Incoming_value == '1')            //Checks whether value of Incoming_value is equal to 1 
      digitalWrite(2, HIGH);  //If value is 1 then LED turns ON
    else if(Incoming_value == '0')       //Checks whether value of Incoming_value is equal to 0
      digitalWrite(2, LOW);   //If value is 0 then LED turns OFF
  }                            
 
}                 
