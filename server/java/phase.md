Phase 0 — Project Foundation & Convention
Mục tiêu: chuẩn hoá kiến trúc + quy ước trước khi code sâu.
Làm:

chốt folder/package structure
chốt response chuẩn ApiResponse<T>
chốt exception handling global
chốt naming endpoint (/api/...)
setup Swagger + CORS cơ bản Done khi:
app chạy local
/swagger-ui/index.html mở được
/health/db pass
Phase 1 — Identity & Authentication Core
Mục tiêu: login/register chạy ổn với JWT access token.

API:

POST /api/authentication/register
POST /api/authentication/login
Làm:

Account entity + repository
password hash BCrypt
AuthService (register/login)
JwtTokenProvider generate/validate token
CustomUserDetailsService load user by email
JwtAuthenticationFilter set SecurityContext
SecurityConfig stateless + permit auth/swagger/health
Done khi:

login trả JWT hợp lệ
gọi API protected có token thì pass, không token thì 401
Phase 2 — Session Continuity (Refresh + Logout)
Mục tiêu: hoàn chỉnh vòng đời token.

API:

POST /api/authentication/refresh-token
POST /api/authentication/logout
Làm:

bảng refresh_token
lưu refresh token theo user/device (ít nhất user)
rotate refresh token khi refresh
revoke token khi logout
Done khi:

access token hết hạn vẫn lấy token mới bằng refresh token
logout xong refresh token cũ không dùng lại được
Phase 3 — Authorization & Role Guard
Mục tiêu: phân quyền chuẩn Admin/Staff/Customer.

Làm:

map role -> ROLE_ADMIN, ROLE_STAFF, ROLE_CUSTOMER
guard route bằng hasRole/@PreAuthorize
chặn endpoint admin-only (create/update/delete product, voucher...)
Done khi:

customer không gọi được admin endpoints
staff gọi đúng subset quyền được định nghĩa
Phase 4 — Master Data Modules (Catalog)
Mục tiêu: hoàn thiện module dữ liệu lõi bán hàng.

Ưu tiên API:

Category
Brand
Ingredient
Function
Skin type questions/answers
Product CRUD + list/filter/detail
Làm:

CRUD chuẩn + validation
pagination/filter/sort
DTO mapping sạch (không expose entity trực tiếp)
Done khi:

FE lấy được danh sách sản phẩm + chi tiết theo danh mục/brand
admin quản trị catalog đầy đủ
Phase 5 — Customer Profile & Address
Mục tiêu: luồng user account hoàn chỉnh.

API:

customer profile
shipping addresses CRUD
Làm:

current user endpoint (/me)
quản lý nhiều địa chỉ giao hàng
validate phone/address fields
Done khi:

customer tự quản lý profile + địa chỉ
role khác không sửa trái phép dữ liệu user
Phase 6 — Cart, Order, Voucher
Mục tiêu: luồng mua hàng end-to-end.

API:

tạo đơn
xem đơn
cập nhật trạng thái đơn (staff/admin)
áp voucher
Làm:

order + order_detail transaction-safe
kiểm tra voucher hợp lệ (thời gian/số lượng/điều kiện)
status flow chuẩn (pending/paid/shipping/completed/cancelled)
Done khi:

tạo đơn thành công, trừ tồn/áp giá đúng
trạng thái đơn chuyển đúng rule
Phase 7 — Payment Integration (VNPay)
Mục tiêu: thanh toán online chạy thật trên sandbox.

API:

POST /api/payments/create-payment-url
GET /api/payments/return
Làm:

ký hash VNPay đúng chuẩn
verify callback
cập nhật transaction + order status idempotent
Done khi:

thanh toán thành công/cancel đều phản ánh đúng vào DB
callback gọi lặp không gây sai trạng thái
Phase 8 — Feedback, Blog, Content
Mục tiêu: hoàn thiện ecosystem nội dung và tương tác.

API:

feedback CRUD (quyền theo role/user)
blog CRUD (admin/staff)
transaction history endpoints
Done khi:

customer gửi feedback đúng quyền
staff/admin quản lý content ổn
Phase 9 — Production Hardening
Mục tiêu: sẵn sàng deploy production.

Làm:

cấu hình appsettings/application.yml theo env
migration strategy (EF Migration/Flyway)
logging/audit/security headers/rate limit (nếu cần)
Docker compose hoàn chỉnh
monitoring cơ bản
Done khi:

deploy được môi trường staging/prod
rollback/migration có quy trình