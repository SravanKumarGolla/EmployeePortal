empApp.controller('employeeCtrl', function ($scope, $http, EmpSrvcv) {

    $scope.isEditMode = false;
    $scope.isDeleteMode = false;
    $scope.EmployeeDetails = [];
    $scope.Employee = {
        Name: '',
        NameArabic: '',
        Age: '',
        DateOfJoin: '',
        LstAddress: [{
            Address: '',
            MobileNumber: '',
            Email:''
        }],
        LstExp: [{
            Company: '',
            NumberOfYears:''
        }]
    };

    $scope.GetEmployeeDetails = function () {
        EmpSrvcv.GetEmployees().then(function (response) {
            $scope.EmployeeDetails = response.data;
            console.log($scope.EmployeeDetails);
        }, function (error) {
            alert('An error occured')
        });
    }

    $scope.UpdateEmployee = function () {
        EmpSrvcv.UpdateEmployee($scope.Employee).then(function (response) {
            $scope.Employee = '';
            $scope.GetEmployeeDetails();
            $scope.isEditMode = false;
            $scope.isDeleteMode = false;
            alert("Employee details updated Successfully")
        }, function (error) {
            $scope.Employee = '';
            alert('an error occured');
        });
    }

    $scope.DeleteEmployee = function () {
        EmpSrvcv.DeleteEmployee($scope.Employee).then(function (response) {
            $scope.Employee = '';
            $scope.GetEmployeeDetails();
            $scope.isEditMode = false;
            $scope.isDeleteMode = false;
            alert("Employee details deleted Successfully")
        }, function (error) {
            $scope.Employee = '';
            alert('an error occured');
        });
    }
  
    $scope.InsertEmployee = function () {
        EmpSrvcv.InsertEmployee($scope.Employee).then(function (response) {
            $scope.Employee = '';
            alert("Employee create Successfully")
        }, function (error) {
            $scope.Employee = '';
            alert('an error occured');
        });
    }


    $scope.DeleteEmployeeDetails = function (empDet) {
        $scope.isEditMode = false;
        $scope.isDeleteMode = true;
        $scope.Employee = empDet;
    }

    $scope.EditEmployeeDetails = function (empDet) {
        $scope.Employee = empDet;
        $scope.isEditMode = true;
        $scope.isDeleteMode = false;
    }
    $scope.GetEmployeeDetails();
});