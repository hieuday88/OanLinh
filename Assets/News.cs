using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class News : MonoBehaviour, IInteractable
{

    public void OnInteract()
    {
        PlayerInteraction.Instance.desText.GetComponentInChildren<TextMeshProUGUI>().text = @"TIN MỚI, 25/2/2015
        Cặp đôi trẻ mất tích một cách bí ẩn

        Cơ quan chức năng vẫn đang tiến hành điều tra vụ mất tích kỳ lạ xảy ra vào tối ngày 25/2. Hai người trẻ – một nam, một nữ – được cho là đang trong mối quan hệ tình cảm, đã không còn xuất hiện tại nơi cư trú kể từ hôm đó.

        Cả hai sống trong một căn nhà nhỏ ở rìa thị trấn, mới dọn đến khoảng vài tháng trước. Người dân xung quanh mô tả họ sống kín đáo nhưng có vẻ hạnh phúc, không có mâu thuẫn gì đáng chú ý. Tuy nhiên, một số nhân chứng cho biết cô gái gần đây thường có biểu hiện lo lắng, hay giật mình vào ban đêm.

        Điều khiến nhiều người rùng mình là thời điểm mất tích trùng khớp chính xác với ngày tròn một năm kể từ khi một vụ tai nạn thương tâm xảy ra với một cô gái trẻ trong cùng khu vực. Vụ việc được xác định là ""chết do tai nạn"", nhưng người thân nạn nhân khi đó từng khẳng định cô gái đã bị hãm hại trước khi qua đời.

        Hiện tại, không có thi thể nào được tìm thấy, nhưng căn nhà nơi cặp đôi sinh sống đã bị phong tỏa để phục vụ điều tra. Một nhân viên điều tra xin giấu tên tiết lộ:

        “Có những dấu hiệu cho thấy họ đã rời đi… nhưng không phải bằng cách thông thường.”

        Cư dân sống gần căn nhà cho biết vẫn thấy bóng một người đứng sau rèm cửa mỗi đêm 25/2, đúng vào khung giờ cặp đôi biến mất.";
        PlayerInteraction.Instance.desText.gameObject.SetActive(!PlayerInteraction.Instance.desText.gameObject.activeSelf);
        PlayerInteraction.Instance.isBusy = !PlayerInteraction.Instance.isBusy;
    }


    public string Infor()
    {
        return "Một tờ báo đã cũ";
    }
}
