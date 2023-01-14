namespace Searching.Infrastructure.Utils;

public static class DomainTemplates
{
    public static string ActivatationSuccess()
    {
        return $@"
                <!DOCTYPE html>
<html>
   <head>
      <style>
         body {{
         background: #1488EA;
         }}
         #card {{
         position: relative;
         top: 110px;
         width: 320px;
         display: block;
         margin: auto;
         text-align: center;
         font-family: 'Source Sans Pro', sans-serif;
         }}
         #upper-side {{
         padding: 2em;
         background-color: #8BC34A;
         display: block;
         color: #fff;
         border-top-right-radius: 8px;
         border-top-left-radius: 8px;
         }}
         #checkmark {{
         font-weight: lighter;
         fill: #fff;
         margin: -3.5em auto auto 20px;
         }}
         #status {{
         font-weight: lighter;
         text-transform: uppercase;
         letter-spacing: 2px;
         font-size: 1em;
         margin-top: -.2em;
         margin-bottom: 0;
         }}
         #lower-side {{
         padding: 2em 2em 5em 2em;
         background: #fff;
         display: block;
         border-bottom-right-radius: 8px;
         border-bottom-left-radius: 8px;
         }}
         #message {{
         margin-top: -.5em;
         color: #757575;
         letter-spacing: 1px;
         }}
         #contBtn {{
         position: relative;
         top: 1.5em;
         text-decoration: none;
         background: #8bc34a;
         color: #fff;
         margin: auto;
         padding: .8em 3em;
         -webkit-box-shadow: 0px 15px 30px rgba(50, 50, 50, 0.21);
         -moz-box-shadow: 0px 15px 30px rgba(50, 50, 50, 0.21);
         box-shadow: 0px 15px 30px rgba(50, 50, 50, 0.21);
         border-radius: 25px;
         -webkit-transition: all .4s ease;
         -moz-transition: all .4s ease;
         -o-transition: all .4s ease;
         transition: all .4s ease;
         }}
         #contBtn:hover {{
         -webkit-box-shadow: 0px 15px 30px rgba(50, 50, 50, 0.41);
         -moz-box-shadow: 0px 15px 30px rgba(50, 50, 50, 0.41);
         box-shadow: 0px 15px 30px rgba(50, 50, 50, 0.41);
         -webkit-transition: all .4s ease;
         -moz-transition: all .4s ease;
         -o-transition: all .4s ease;
         transition: all .4s ease;
         }}
         .ui-success,
         .ui-error {{
         width: 100px;
         height: 100px;
         margin: 1rem auto;
         }}
         .ui-success-circle {{
         stroke-dasharray: 260.75219025px, 260.75219025px;
         stroke-dashoffset: 260.75219025px;
         transform: rotate(220deg);
         transform-origin: center center;
         stroke-linecap: round;
         animation: ani-success-circle 1s ease-in both;
         }}
         .ui-success-path {{
         stroke-dasharray: 60px 64px;
         stroke-dashoffset: 62px;
         stroke-linecap: round;
         animation: ani-success-path 0.4s 1s ease-in both;
         }}
         @keyframes ani-success-circle {{
         to {{
         stroke-dashoffset: 782.25657074px;
         }}
         }}
         @keyframes ani-success-path {{
         0% {{
         stroke-dashoffset: 62px;
         }}
         65% {{
         stroke-dashoffset: -5px;
         }}
         84% {{
         stroke-dashoffset: 4px;
         }}
         100% {{
         stroke-dashoffset: -2px;
         }}
         }}
         .ui-error-circle {{
         stroke-dasharray: 260.75219025px, 260.75219025px;
         stroke-dashoffset: 260.75219025px;
         animation: ani-error-circle 1.2s linear;
         }}
         .ui-error-line1 {{
         stroke-dasharray: 54px 55px;
         stroke-dashoffset: 55px;
         stroke-linecap: round;
         animation: ani-error-line 0.15s 1.2s linear both;
         }}
         .ui-error-line2 {{
         stroke-dasharray: 54px 55px;
         stroke-dashoffset: 55px;
         stroke-linecap: round;
         animation: ani-error-line 0.2s 0.9s linear both;
         }}
         @keyframes ani-error-line {{
         to {{
         stroke-dashoffset: 0;
         }}
         }}
         @keyframes ani-error-circle {{
         0% {{
         stroke-dasharray: 0, 260.75219025px;
         stroke-dashoffset: 0;
         }}
         35% {{
         stroke-dasharray: 120px, 120px;
         stroke-dashoffset: -120px;
         }}
         70% {{
         stroke-dasharray: 0, 260.75219025px;
         stroke-dashoffset: -260.75219025px;
         }}
         100% {{
         stroke-dasharray: 260.75219025px, 0;
         stroke-dashoffset: -260.75219025px;
         }}
         }}
      </style>
   </head>
   <div id='card' class='animated fadeIn'>
      <div id='upper-side'>
         <div class='ui-success'>
            <svg viewBox='0 0 87 87' version='1.1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink'>
               <g id='Page-1' stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                  <g id='Group-3' transform='translate(2.000000, 2.000000)'>
                     <circle id='Oval-2' stroke='rgba(255, 255, 255, 1)' stroke-width='4' cx='41.5' cy='41.5' r='41.5'></circle>
                     <circle class='ui-success-circle' id='Oval-2' stroke='#fff' stroke-width='4' cx='41.5' cy='41.5' r='41.5'></circle>
                     <polyline class='ui-success-path' id='Path-2' stroke='#fff' stroke-width='4' points='19 38.8036813 31.1020744 54.8046875 63.299221 28'></polyline>
                  </g>
               </g>
            </svg>
         </div>
         <h3 id='status'>
            Success
         </h3>
      </div>
      <div id='lower-side'>
         <p id='message'>
            Congratulations, your account has been successfully Activated.
         </p>
      </div>
   </div>
        ";
    }

    public static string FailedActivation(string message)
    {
        return $@"
                <!DOCTYPE html>
<html>
   <head>
      <style>
         body {{
         background: #1488EA;
         }}
         #card {{
         position: relative;
         top: 110px;
         width: 320px;
         display: block;
         margin: auto;
         text-align: center;
         font-family: 'Source Sans Pro', sans-serif;
         }}
         #upper-side {{
         padding: 2em;
         background-color: #e32c2c;
         display: block;
         color: #fff;
         border-top-right-radius: 8px;
         border-top-left-radius: 8px;
         }}
         #checkmark {{
         font-weight: lighter;
         fill: #fff;
         margin: -3.5em auto auto 20px;
         }}
         #status {{
         font-weight: lighter;
         text-transform: uppercase;
         letter-spacing: 2px;
         font-size: 1em;
         margin-top: -.2em;
         margin-bottom: 0;
         }}
         #lower-side {{
         padding: 2em 2em 5em 2em;
         background: #fff;
         display: block;
         border-bottom-right-radius: 8px;
         border-bottom-left-radius: 8px;
         }}
         #message {{
         margin-top: -.5em;
         color: #757575;
         letter-spacing: 1px;
         }}
         #contBtn {{
         position: relative;
         top: 1.5em;
         text-decoration: none;
         background: #8bc34a;
         color: #fff;
         margin: auto;
         padding: .8em 3em;
         -webkit-box-shadow: 0px 15px 30px rgba(50, 50, 50, 0.21);
         -moz-box-shadow: 0px 15px 30px rgba(50, 50, 50, 0.21);
         box-shadow: 0px 15px 30px rgba(50, 50, 50, 0.21);
         border-radius: 25px;
         -webkit-transition: all .4s ease;
         -moz-transition: all .4s ease;
         -o-transition: all .4s ease;
         transition: all .4s ease;
         }}
         #contBtn:hover {{
         -webkit-box-shadow: 0px 15px 30px rgba(50, 50, 50, 0.41);
         -moz-box-shadow: 0px 15px 30px rgba(50, 50, 50, 0.41);
         box-shadow: 0px 15px 30px rgba(50, 50, 50, 0.41);
         -webkit-transition: all .4s ease;
         -moz-transition: all .4s ease;
         -o-transition: all .4s ease;
         transition: all .4s ease;
         }}
         .ui-error {{
         width: 100px;
         height: 100px;
         margin: 40px;
         margin: 1rem auto;
         }}
         .ui-success-circle {{
         stroke-dasharray: 260.75219025px, 260.75219025px;
         stroke-dashoffset: 260.75219025px;
         transform: rotate(220deg);
         transform-origin: center center;
         stroke-linecap: round;
         animation: ani-success-circle 1s ease-in both;
         }}
         .ui-success-path {{
         stroke-dasharray: 60px 64px;
         stroke-dashoffset: 62px;
         stroke-linecap: round;
         animation: ani-success-path 0.4s 1s ease-in both;
         }}
         @keyframes ani-success-circle {{
         to {{
         stroke-dashoffset: 782.25657074px;
         }}
         }}
         @keyframes ani-success-path {{
         0% {{
         stroke-dashoffset: 62px;
         }}
         65% {{
         stroke-dashoffset: -5px;
         }}
         84% {{
         stroke-dashoffset: 4px;
         }}
         100% {{
         stroke-dashoffset: -2px;
         }}
         }}
         .ui-error-circle {{
         stroke-dasharray: 260.75219025px, 260.75219025px;
         stroke-dashoffset: 260.75219025px;
         animation: ani-error-circle 1.2s linear;
         }}
         .ui-error-line1 {{
         stroke-dasharray: 54px 55px;
         stroke-dashoffset: 55px;
         stroke-linecap: round;
         animation: ani-error-line 0.15s 1.2s linear both;
         }}
         .ui-error-line2 {{
         stroke-dasharray: 54px 55px;
         stroke-dashoffset: 55px;
         stroke-linecap: round;
         animation: ani-error-line 0.2s 0.9s linear both;
         }}
         @keyframes ani-error-line {{
         to {{
         stroke-dashoffset: 0;
         }}
         }}
         @keyframes ani-error-circle {{
         0% {{
         stroke-dasharray: 0, 260.75219025px;
         stroke-dashoffset: 0;
         }}
         35% {{
         stroke-dasharray: 120px, 120px;
         stroke-dashoffset: -120px;
         }}
         70% {{
         stroke-dasharray: 0, 260.75219025px;
         stroke-dashoffset: -260.75219025px;
         }}
         100% {{
         stroke-dasharray: 260.75219025px, 0;
         stroke-dashoffset: -260.75219025px;
         }}
         }}
      </style>
   </head>
   <div id='card' class='animated fadeIn'>
      <div id='upper-side'>
         <div class='ui-error'>
            <svg viewBox='0 0 87 87' version='1.1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink'>
               <g id='Page-1' stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'>
                  <g id='Group-2' transform='translate(2.000000, 2.000000)'>
                     <circle id='Oval-2' stroke='rgba(255, 255, 255, 1)' stroke-width='4' cx='41.5' cy='41.5' r='41.5'></circle>
                     <circle class='ui-error-circle' stroke='#F74444' stroke-width='4' cx='41.5' cy='41.5' r='41.5'></circle>
                     <path class='ui-error-line1' d='M22.244224,22 L60.4279902,60.1837662' id='Line' stroke='#FFF' stroke-width='3' stroke-linecap='square'></path>
                     <path class='ui-error-line2' d='M60.755776,21 L23.244224,59.8443492' id='Line' stroke='#FFF' stroke-width='3' stroke-linecap='square'></path>
                  </g>
               </g>
            </svg>
         </div>
         <h3 id='status'>
            Failed
         </h3>
      </div>
      <div id='lower-side'>
         <p id='message'>
            {message}
         </p>
      </div>
   </div>
        ";
    }

}