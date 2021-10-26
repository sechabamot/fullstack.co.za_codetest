export class InputValidation {

    constructor(inputType:InputType, value:any){
        
        this._inputType = inputType;
        this._value = value;

    }

    private _inputType: InputType;
    private _isValid: boolean = false;
    private _value: any;

    //Bootstrap class 'is-valid' or 'is-invalid'.
    public ClassValue: string = ''
    public ResponseMessage: string = '';

    public get Value(){
        return this._value;
    }
    public set Value(value:any){
        this._value = value;
        this._isValid = this.validateInput();
        if(this._isValid){
            this.ClassValue = 'is-valid';
        } else{
            this.ClassValue = 'is-invalid'
        }
    }
    public get IsValid(){
        return this._isValid;
    } 
    
    validateInput(){
        
        //Name validation
        if (this._inputType == InputType.Name){
            
            let name = this.Value as string
            if(name.length < 3){

                this.ResponseMessage = "Name must be atleast 3 characters long"
                return false;
            }
        }
        //Email validation
        if (this._inputType == InputType.Email){
            
            let email = this.Value as string
            const regularExpression = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

            if(email == "" || !regularExpression.test(String(email).toLowerCase())){
                
                this.ResponseMessage = "Please enter a valid email"
                return false;
            }
        }
        //Password
        if (this._inputType == InputType.Password){
            
            const password = this.Value as string
            const minNumberofChars = 8;
            const maxNumberofChars = 16;
            const regularExpression = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,16}$/;

            if(password.length < minNumberofChars){
                this.ResponseMessage = "Password must be atleast 8 characters long" 
                return false;
            }

            if(password.length > maxNumberofChars){
                this.ResponseMessage = "Password cannot be more that 16 characters long" 
                return false;
            }

            if(!regularExpression.test(password)) {
                this.ResponseMessage = "Password should contain atleast one number and one special character";
                return false;
            }

        }

        this.ResponseMessage = "";
        return true;

    }
}

export enum InputType{
    Name = 0, Email = 1, Password = 3, 
}