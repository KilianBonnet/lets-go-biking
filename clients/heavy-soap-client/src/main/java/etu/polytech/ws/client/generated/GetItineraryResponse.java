
package etu.polytech.ws.client.generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="GetItineraryResult" type="{http://schemas.datacontract.org/2004/07/routing_server.Implementation}LgbDirections" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "getItineraryResult"
})
@XmlRootElement(name = "GetItineraryResponse", namespace = "http://tempuri.org/")
public class GetItineraryResponse {

    @XmlElementRef(name = "GetItineraryResult", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<LgbDirections> getItineraryResult;

    /**
     * Gets the value of the getItineraryResult property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link LgbDirections }{@code >}
     *     
     */
    public JAXBElement<LgbDirections> getGetItineraryResult() {
        return getItineraryResult;
    }

    /**
     * Sets the value of the getItineraryResult property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link LgbDirections }{@code >}
     *     
     */
    public void setGetItineraryResult(JAXBElement<LgbDirections> value) {
        this.getItineraryResult = value;
    }

}
