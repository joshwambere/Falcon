namespace Searching.Infrastructure.Utils;

public static class EmailTemplateEngine
{

    public static string ActivationMail(string senderName , string url)
    {
        var html = $@"
        <head>

        </head>

        <body style='background: #F9F9F9;'>
          <div style='background-color:#F9F9F9;'>

            <div style='margin:0px auto;max-width:640px;background:transparent;'>
              
                              </td>
                            </tr>
                          </tbody>
                        </table>
                      </div>

                    </td>
                  </tr>
                </tbody>
              </table>
            </div>

            <div style='max-width:640px;margin:0 auto;box-shadow:0px 1px 5px rgba(0,0,0,0.1);border-radius:4px;overflow:hidden'>
              

                <table role='presentation' cellpadding='0' cellspacing='0' style='font-size:0px;width:100%;background:#7289DA url(https://cdn.discordapp.com/email_assets/f0a4cc6d7aaa7bdf2a3c15a193c6d224.png) top center / cover no-repeat;' align='center' border='0' background='https://cdn.discordapp.com/email_assets/f0a4cc6d7aaa7bdf2a3c15a193c6d224.png'>
                  <tbody>
                    <tr>
                      <td style='text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:57px;'>

                        <div style='cursor:auto;color:white;font-family:Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-size:36px;font-weight:600;line-height:36px;text-align:center;'>Welcome to Esomero!</div>

                      </td>
                    </tr>
                  </tbody>
                </table>

              </div>

              <div style='margin:0px auto;max-width:640px;background:#ffffff;'>
                <table role='presentation' cellpadding='0' cellspacing='0' style='font-size:0px;width:100%;background:#ffffff;' align='center' border='0'>
                  <tbody>
                    <tr>
                      <td style='text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:40px 70px;'>

                        <div aria-labelledby='mj-column-per-100' class='mj-column-per-100 outlook-group-fix' style='vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%;'>
                          <table role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>
                            <tbody>
                              <tr>
                                <td style='word-break:break-word;font-size:0px;padding:0px 0px 20px;' align='left'>
                                  <div style='cursor:auto;color:#737F8D;font-family:Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-size:16px;line-height:24px;text-align:left;'>
                                    <p><img src='https://cdn.discordapp.com/email_assets/127c95bbea39cd4bc1ad87d1500ae27d.png' alt='Party Wumpus' title='None' width='500' style='height: auto;'></p>

                                    <h2 style='font-family: Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-weight: 500;font-size: 20px;color: #4F545C;letter-spacing: 0.27px;'>Hey {senderName} </h2>
                                    <p>Wowwee! Thanks for registering an account with Esomero! You're the coolest person in all the land (and I've met a lot of really cool people).</p>
                                    <p>Before we get started, we'll need to verify your email.</p>

                                  </div>
                                </td>
                              </tr>
                              <tr>
                                <td style='word-break:break-word;font-size:0px;padding:10px 25px;' align='cente' <table role='presentation' cellpadding='0' cellspacing='0' style='border-collapse:separate;' align='center' border='0'>
                            <tbody>
                              <tr>
                                <td style='border:none;border-radius:3px;color:white;cursor:auto;padding:15px 19px;' align='center' valign='middle' bgcolor='#7289DA'><a href='{url}' style='text-decoration:none;line-height:100%;background:#7289DA;color:white;font-family:Ubuntu, Helvetica, Arial, sans-serif;font-size:15px;font-weight:normal;text-transform:none;margin:0px;' target='_blank'>
                                    Verify Email
                                  </a></td>
                              </tr>
                            </tbody>
                          </table>
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>

              </td>
              </tr>
              </tbody>
              </table>
            </div>

          </div>
          <div style='margin:0px auto;max-width:640px;background:transparent;'>
            <table role='presentation' cellpadding='0' cellspacing='0' style='font-size:0px;width:100%;background:transparent;' align='center' border='0'>
              <tbody>
                <tr>
                  <td style='text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:0px;'>

                    <div aria-labelledby='mj-column-per-100' class='mj-column-per-100 outlook-group-fix' style='vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%;'>
                      <table role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>
                        <tbody>
                          <tr>
                            <td style='word-break:break-word;font-size:0px;'>
                              <div style='font-size:1px;line-height:12px;'>&nbsp;</div>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    </div>

                  </td>
                </tr>
              </tbody>
            </table>
          </div>

          <div style='margin:0 auto;max-width:640px;background:#ffffff;box-shadow:0px 1px 5px rgba(0,0,0,0.1);border-radius:4px;overflow:hidden;'>
            <table cellpadding='0' cellspacing='0' style='font-size:0px;width:100%;background:#ffffff;' align='center' border='0'>
              <tbody>
                <tr>
                  <td style='text-align:center;vertical-align:top;font-size:0px;padding:0px;'>

                    <div aria-labelledby='mj-column-per-100' class='mj-column-per-100 outlook-group-fix' style='vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%;'>
                      <table role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>
                        <tbody>
                          <tr>
                            <td style='word-break:break-word;font-size:0px;padding:30px 70px 0px 70px;' align='center'>
                              <div style='cursor:auto;color:#43B581;font-family:Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-size:18px;font-weight:bold;line-height:16px;text-align:center;'>FUN FACT #16</div>
                            </td>
                          </tr>
                          <tr>
                            <td style='word-break:break-word;font-size:0px;padding:14px 70px 30px 70px;' align='center'>
                              <div style='cursor:auto;color:#737F8D;font-family:Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-size:16px;line-height:22px;text-align:center;'>
                                The longest book in the world is ‘Remembrance of Things Past.
                              </div>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    </div>

                  </td>
                </tr>
              </tbody>
            </table>
          </div>

          <div style='margin:0px auto;max-width:640px;background:transparent;'>
            <table role='presentation' cellpadding='0' cellspacing='0' style='font-size:0px;width:100%;background:transparent;' align='center' border='0'>
              <tbody>
                <tr>
                  <td style='text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:20px 0px;'>

                    <div aria-labelledby='mj-column-per-100' class='mj-column-per-100 outlook-group-fix' style='vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%;'>
                      <table role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'>
                        <tbody>
                          <tr>
                            <td style='word-break:break-word;font-size:0px;padding:0px;' align='center'>
                              <div style='cursor:auto;color:#99AAB5;font-family:Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-size:12px;line-height:24px;text-align:center;'>
                                Sent by eSomero • <a href='https://blog.discordapp.com/' style='color:#1EB0F4;text-decoration:none;' target='_blank'>check our blog</a> • <a href='https://johnson.rw' style='color:#1EB0F4;text-decoration:none;' target='_blank'>@esomero</a>
                              </div>
                            </td>
                          </tr>
                          <tr>
                            <td style='word-break:break-word;font-size:0px;padding:0px;' align='center'>
                              <div style='cursor:auto;color:#99AAB5;font-family:Whitney, Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif;font-size:12px;line-height:24px;text-align:center;'>
                                KK 218 Kigali Kicukiro, Rwanda
                              </div>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    </div>

                  </td>
                </tr>
              </tbody>
            </table>
          </div>

          </div>

        </body>
        ";

        return html;

    }
}
