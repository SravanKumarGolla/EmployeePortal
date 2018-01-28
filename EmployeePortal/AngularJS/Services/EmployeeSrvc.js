empApp.service('EmpSrvcv', function ($http) {
    this.GetEmployees = function () {
        return $http.get('/api/Employee/');
    }

    this.DeleteEmployee = function (emp) {
        return $http({
            method: 'delete',
            url: '/api/Employee/',
            data: emp,
            headers: {
                "Content-Type": "application/json"
            }
        })
    }

    this.UpdateEmployee = function (emp) {
        return $http({
            method: 'put',
            url: '/api/Employee/',
            data: emp,
            headers: {
                "Content-Type": "application/json"
            }
        });
    }

    this.InsertEmployee = function (emp) {

        var DTO = JSON.stringify(emp);

        return $http({
            method: 'post',
            url: '/api/Employee/',
            contentType: 'application/json; charset=utf-8',
            data: DTO,
            cache: false,
        });
    }
})