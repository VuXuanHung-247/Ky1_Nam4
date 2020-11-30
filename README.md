# Ky1_Nam4
A++ cùng ae Nhà nghỉ
Works
- Thứ 4 - 28/10/2020 : Tạo csdl Môn Công nghệ lập trình tích hợp nhé
- Thứ 5/6 - 29-30/10/2020: Báo cáo Đánh giá chất lượng phần mềm
- Project gồm: BaseLib, DataService, SportShop (MVC)
  + BaseLib: là Model cho project
  + DataService: * là tầng kết nối với CSDL, query & thủ tục(SP) của CSDL
                 * là tầng viết các Api cho dự án, bao gồm: Api, BLL, DAL
                   - Api: ta dùng để viết các phương thức Get, Post, Put, Delete, Api sẽ gọi xuống BLL để xử lý tiếp cho các phương thức này
                   - BLL(Business Logic Layer): là tầng nghiệp vụ của Api, ngoài ra còn có thể viết logic ở đây ( nhưng ở đây k dùng ), BLL sẽ gọi xuống DAL để xử lý tiếp phương thức bên trên
                   - DAL(Data Access Layer): là tầng kết nốt với CSDL, gọi đến thủ tục(SP) được dùng cho phương thức bên trên ( Get, Post, Put, Delete )
  + SportShop: * phần View là chính
               * Controller chủ yếu chỉ dùng để add View cho API đã viết
               * dùng MVC ở đây thôi
