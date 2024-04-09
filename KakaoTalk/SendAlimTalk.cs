using System;

namespace CommonLib.KakaoTalk
{
    public static class SendAlimTalk
    {
        public static void Send(MessagingLib.Message message)
        {
            // 텍스트 내용이 있는 알림톡 메시지 생성
            MessagingLib.Messages messages = new MessagingLib.Messages();

            // messages에 Add 
            messages.Add(message);

            // 알림톡 전송
            MessagingLib.Response response =  MessagingLib.SendMessages(messages);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // MessageBox로 전송 결과 출력
                Console.WriteLine("전송 결과" + Environment.NewLine + "Group ID:" + response.Data.SelectToken("groupId").ToString() + Environment.NewLine + "Status:" + response.Data.SelectToken("status").ToString() + Environment.NewLine + "Count:" + response.Data.SelectToken("count").ToString());
            }
            else
            {
                // Error MessageBox로 전송 결과 출력
                Console.WriteLine("Error Code:" + response.ErrorCode + Environment.NewLine + "Error Message:" + response.ErrorMessage);
            }

        }
    }
}