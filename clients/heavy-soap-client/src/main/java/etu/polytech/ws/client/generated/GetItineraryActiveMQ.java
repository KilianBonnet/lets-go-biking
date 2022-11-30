
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
 *         &lt;element name="departureAddress" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/&gt;
 *         &lt;element name="arrivalAddress" type="{http://www.w3.org/2001/XMLSchema}string" minOccurs="0"/&gt;
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
    "departureAddress",
    "arrivalAddress"
})
@XmlRootElement(name = "GetItineraryActiveMQ")
public class GetItineraryActiveMQ {

    @XmlElementRef(name = "departureAddress", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<String> departureAddress;
    @XmlElementRef(name = "arrivalAddress", namespace = "http://tempuri.org/", type = JAXBElement.class, required = false)
    protected JAXBElement<String> arrivalAddress;

    /**
     * Gets the value of the departureAddress property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getDepartureAddress() {
        return departureAddress;
    }

    /**
     * Sets the value of the departureAddress property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setDepartureAddress(JAXBElement<String> value) {
        this.departureAddress = value;
    }

    /**
     * Gets the value of the arrivalAddress property.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public JAXBElement<String> getArrivalAddress() {
        return arrivalAddress;
    }

    /**
     * Sets the value of the arrivalAddress property.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link String }{@code >}
     *     
     */
    public void setArrivalAddress(JAXBElement<String> value) {
        this.arrivalAddress = value;
    }

}
