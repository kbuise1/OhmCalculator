# OhmCalculator
Application to calculate ohms for resistor bands.  User selects available color from from drop down list for corresponding band and the ohm value/range is calculated.  Application implments ASP.NET MVC design pattern using C# and html. 


Prerequisites/Install
To run application visual studio or any IDE compatible and IIS.
Steps:
Download project.
Open solution in IDE and run on localhost or from command line run the executable from project (projectname\bin\Release\projectname.exe)


Test
There are two test per method in the controller.  One test to assert the correct view/model is being returned and one test to assert the correct calculations/values are being passed.


Comments
I decided not to implement the interface because it appeared more efficient to me to have a list with key/value pairs. For one it made for less error/input from user.  Also I used a model as the parameter for the calculation method and to me that made the interface less interchangable by having such a specific parameter such as a model. Also I implemented my partial view with ajax but out of the blue i started to recieve a 404 error that the unobtrusive package could not be found though it was installed and called just like the other working scripts. So the values in the partial view don't update on the screen though it does behind the scenes. To get a new calculation you must refresh the page.

I did implement a version using the interface in the beginning.  I changed the interface method signature to return an array to store the multiple calculation values.  I then used switch case methods to return the corresponding values to do the calculations. Shown below:


        public class HomeController : Controller, IOhmValueCalculator
            {

                public float[] CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor){
                float val = GetSigFigure(bandAColor) * 10 + GetSigFigure(bandBColor)) * GetMultiplier(bandCColor);

                        if (bandDColor != null)
                        {
                            float tolerance = GetTolerance(bandDColor, val);
                            float[] output = { val - tolerance, val + tolerance };
                            return output;
                        }
                        else
                        {
                            float[] output = { val, };
                            return output;
                        }
                };

        };
            
            
            public float GetSigFigure(){
            switch (color.ToLower())
                    {
                    case "pink":
                            return 0.001f;
                        case "silver":
                            return 0.01f;
                       };
                       
               };




