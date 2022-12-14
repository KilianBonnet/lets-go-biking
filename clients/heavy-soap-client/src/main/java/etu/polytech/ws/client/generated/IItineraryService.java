
package etu.polytech.ws.client.generated;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebResult;
import javax.jws.WebService;
import javax.xml.bind.annotation.XmlSeeAlso;
import javax.xml.ws.RequestWrapper;
import javax.xml.ws.ResponseWrapper;


/**
 * This class was generated by the JAX-WS RI.
 * JAX-WS RI 2.3.2
 * Generated source version: 2.2
 * 
 */
@WebService(name = "IItineraryService", targetNamespace = "http://tempuri.org/")
@XmlSeeAlso({
    ObjectFactory.class
})
public interface IItineraryService {


    /**
     * 
     * @param departureAddress
     * @param arrivalAddress
     * @return
     *     returns etu.polytech.ws.client.generated.LgbDirections
     */
    @WebMethod(operationName = "GetItinerary", action = "http://tempuri.org/IItineraryService/GetItinerary")
    @WebResult(name = "GetItineraryResult", targetNamespace = "http://tempuri.org/")
    @RequestWrapper(localName = "GetItinerary", targetNamespace = "http://tempuri.org/", className = "etu.polytech.ws.client.generated.GetItinerary")
    @ResponseWrapper(localName = "GetItineraryResponse", targetNamespace = "http://tempuri.org/", className = "etu.polytech.ws.client.generated.GetItineraryResponse")
    public LgbDirections getItinerary(
        @WebParam(name = "departureAddress", targetNamespace = "http://tempuri.org/")
        String departureAddress,
        @WebParam(name = "arrivalAddress", targetNamespace = "http://tempuri.org/")
        String arrivalAddress);

}
