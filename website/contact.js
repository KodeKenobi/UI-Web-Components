const subService = document.getElementById("subService");
subService.disabled = true;

const serviceValue = ["Application Services", "IT Consultancy", "Data Analytics", "Others" ];
const AS = ["Application management","Application modernization","Application integration","Application security services", "Application development", "Application testing", "Application maintenance and support", "All of these"];
const IC = ["Digital Transformation Consulting","Digital Crisis Management Consulting","Project Management Consulting","IT Service Management Consulting", "Solution consulting", "Platform consulting", "Enterprise IT consulting", "All of these"];
const DA = ["Business Intelligence","Data Warehousing","Data Management","Big Data", "Data Science", "Machine and Deep Learning", "Data Analytics as a Service","All of these"];

function changeValue(){
    subService.innerHTML = "<option value='' hidden>Choose a sub-service</option>";
    let value  =  document.getElementById("mainService").value ;
    console.log(value);
    if(value === serviceValue[0]){
        subService.disabled = false;
        for(let i = 0; i<AS.length ; i++ ){
            subService.innerHTML = subService.innerHTML + "<option value='"+AS[i]+"'>"+AS[i]+"</option>";
        }

    }
    else if(value === serviceValue[1]){
        subService.disabled = false;
        for(let i = 0; i<IC.length ; i++ ){
            subService.innerHTML = subService.innerHTML + "<option value='"+IC[i]+"'>"+IC[i]+"</option>";
        }

    }
    else if(value === serviceValue[2]){
        subService.disabled = false;
        for(let i = 0; i<DA.length ; i++ ){
            subService.innerHTML = subService.innerHTML + "<option value='"+DA[i]+"'>"+DA[i]+"</option>";
        }

    }
    else{
        subService.disabled = true;
    }
}