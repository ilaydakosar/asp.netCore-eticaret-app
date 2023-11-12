import { Injectable } from '@angular/core';
declare var alertify:any;
@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }
  //message(message:string,messageType:MessageType,position :Position,delay:number=3,dismissOthers:boolean=false )
  message(message:string ,options:Partial<AlertifyOptions>)
  {
    alertify.set('notifier','delay', options.delay);
    alertify.set('notifier','position',options.position );
   const mjs= alertify[options.messageType](message);
    if (options.dismissOthers)
    mjs.dismissOthers();
  }
  dismiss()
{
  alertify.dismissAll();
}
}

export class AlertifyOptions {
messageType:MessageType = MessageType.Message;
position :Position = Position.BottomLeft;
delay :number =3;
dismissOthers:boolean = false;
}

export enum MessageType{
  Error ="error",
  Message="message",
  Notify="notify",
  Success ="success",
  Warning ="warning"
}

export enum Position
{
  BottomRight="bottom-right",
  TopRight="top-right",
  TopCenter="top-center",
  TopLeft="top-left",
  BottomLeft="bottom-right",
  BottomCenter ="bottom-center"
}