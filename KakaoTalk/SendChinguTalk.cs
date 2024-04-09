using System;

namespace CommonLib.KakaoTalk
{
    public static class SendChinguTalk
    {
        public static void Send(string strTo, string strFrom, string strText, string strPfID)
        {
            MessagingLib.Messages messages = new MessagingLib.Messages();

            messages.Add(new MessagingLib.Message()
            {
                to = strTo,
                from = strFrom,
                text = strText,
                kakaoOptions = new MessagingLib.KakaoOptions()
                {
                    pfId = strPfID,
                }
            });

            //// 친구톡 이미지 업로드
            //MessagingLib.Response imgResp = MessagingLib.UploadKakaoImage("testImage.png", "http://www.jinyuone.com");
            //string imageId = imgResp.Data.SelectToken("fileId").ToString();

            //// 친구톡 이미지 발송
            //messages.Add(new MessagingLib.Message()
            //{
            //    to = "01086376202",
            //    from = "01097515838",
            //    text = "진유원 홈페이지 입니다. 배너를 클릭하면 홈페이지로 이동합니다.",
            //    kakaoOptions = new MessagingLib.kakaoOptions()
            //    {
            //        pfId = "KA01PF2003231823450315DkKiV8H3m3",
            //        imageId = imageId
            //    }
            //});

            // 모든 종류의 버튼 예시
            //messages.Add(new MessagingLib.Message()
            //{
            //    to = "01041865838",
            //    from = "01097515838",
            //    text = "광고를 포함하여 어떤 내용이든 입력 가능합니다.",
            //    kakaoOptions = new MessagingLib.kakaoOptions()
            //    {
            //        pfId = "KA01PF2003231823450315DkKiV8H3m3",
            //        buttons = new MessagingLib.KakaoButton[]
            //        {
            //            new MessagingLib.KakaoButton()
            //            {
            //                buttonType = "WL",
            //                buttonName = "시작하기",
            //                linkMo = "https://m.example.com",
            //                linkPc = "https://example.com"
            //            },
            //            //new MessagingLib.KakaoButton()
            //            //{
            //            //    buttonType = "AL",
            //            //    buttonName = "앱 실행",
            //            //    linkAnd = "examplescheme://",
            //            //    linkIos = "examplescheme://"
            //            //},
            //            //new MessagingLib.KakaoButton()
            //            //{
            //            //    buttonType = "BK",
            //            //    buttonName = "봇키워드"
            //            //},
            //            // 상담톡 이용 가능 고객만 사용 가능
            //            //new MessagingLib.KakaoButton()
            //            //{
            //            //    buttonType = "MD",
            //            //    buttonName = "상담요청하기"
            //            //}
            //        }
            //    }
            //});

            MessagingLib.Response response = MessagingLib.SendMessages(messages);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("전송 결과");
                Console.WriteLine("Group ID:" + response.Data.SelectToken("groupId").ToString());
                Console.WriteLine("Status:" + response.Data.SelectToken("status").ToString());
                Console.WriteLine("Count:" + response.Data.SelectToken("count").ToString());
            }
            else
            {
                Console.WriteLine("Error Code:" + response.ErrorCode);
                Console.WriteLine("Error Message:" + response.ErrorMessage);
            }

        }

        public static void SendSimpleMsg(string strTo, string strFrom, string strText, string strPfID)
        {
            MessagingLib.Messages messages = new MessagingLib.Messages();

            messages.Add(new MessagingLib.Message()
            {
                to = strTo,
                from = strFrom,
                text = strText,
                kakaoOptions = new MessagingLib.KakaoOptions()
                {
                    pfId = strPfID,
                }
            });

            SendMessage(messages);

        }

        public static void SendButtonLink(string strTo, string strFrom, string strText, MessagingLib.KakaoOptions kakaoOptions)
        {
            MessagingLib.Messages messages = new MessagingLib.Messages();

            messages.Add(new MessagingLib.Message()
            {
                // 모든 종류의 버튼 예시
                to = strTo,
                from = strFrom,
                //text = "광고를 포함하여 어떤 내용이든 입력 가능합니다.",
                text = strText,
                kakaoOptions = kakaoOptions,
            });

            SendMessage(messages);

        }

        public static void SendImageLink(string strTo, string strFrom, string strText, string strPfID, string strImageId)
        {
            MessagingLib.Messages messages = new MessagingLib.Messages();

            // 친구톡 이미지 발송
            messages.Add(new MessagingLib.Message()
            {
                to = strTo,
                from = strFrom,
                text = strText,
                kakaoOptions = new MessagingLib.KakaoOptions()
                {
                    pfId = strPfID,
                    imageId = strImageId
                }
            });

            SendMessage(messages);
        }

        private static void SendMessage(MessagingLib.Messages messages)
        {
            MessagingLib.Response response = MessagingLib.SendMessages(messages);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("전송 결과");
                Console.WriteLine("Group ID:" + response.Data.SelectToken("groupId").ToString());
                Console.WriteLine("Status:" + response.Data.SelectToken("status").ToString());
                Console.WriteLine("Count:" + response.Data.SelectToken("count").ToString());
            }
            else
            {
                Console.WriteLine("Error Code:" + response.ErrorCode);
                Console.WriteLine("Error Message:" + response.ErrorMessage);
            }
        }
    }
}
